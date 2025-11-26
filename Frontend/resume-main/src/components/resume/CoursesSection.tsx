import { useEffect, useState } from "react";
import { supabase } from "@/integrations/supabase/client";
import { Button } from "@/components/ui/button";
import { Plus, Pencil, Trash2 } from "lucide-react";
import { useToast } from "@/hooks/use-toast";
import { CourseDialog } from "./CourseDialog";

interface Course {
  id: string;
  course_type: number;
  title: string;
  location: string;
  institute: string;
  resume: string;
  start_date: string;
  end_date: string;
}

export function CoursesSection({ resumeId }: { resumeId: string }) {
  const [courses, setCourses] = useState<Course[]>([]);
  const [loading, setLoading] = useState(true);
  const [dialogOpen, setDialogOpen] = useState(false);
  const [editingCourse, setEditingCourse] = useState<Course | null>(null);
  const { toast } = useToast();

  useEffect(() => {
    fetchCourses();
  }, [resumeId]);

  const fetchCourses = async () => {
    const { data, error } = await supabase
      .from("courses")
      .select("*")
      .eq("resume_id", resumeId)
      .order("start_date", { ascending: false });

    if (error) {
      toast({
        variant: "destructive",
        title: "Error",
        description: "Failed to fetch courses",
      });
    } else {
      setCourses(data || []);
    }
    setLoading(false);
  };

  const handleDelete = async (id: string) => {
    const { error } = await supabase.from("courses").delete().eq("id", id);

    if (error) {
      toast({
        variant: "destructive",
        title: "Error",
        description: "Failed to delete course",
      });
    } else {
      toast({
        title: "Deleted",
        description: "Course deleted successfully",
      });
      fetchCourses();
    }
  };

  const handleEdit = (course: Course) => {
    setEditingCourse(course);
    setDialogOpen(true);
  };

  const handleAdd = () => {
    setEditingCourse(null);
    setDialogOpen(true);
  };

  const handleSuccess = () => {
    setDialogOpen(false);
    setEditingCourse(null);
    fetchCourses();
  };

  if (loading) {
    return <div>Loading...</div>;
  }

  return (
    <div className="space-y-4">
      <div className="flex justify-between items-center">
        <h3 className="text-lg font-semibold">Education & Courses</h3>
        <Button onClick={handleAdd} size="sm">
          <Plus className="h-4 w-4 mr-2" />
          Add Course
        </Button>
      </div>

      {courses.length === 0 ? (
        <p className="text-muted-foreground text-center py-8">No courses added yet</p>
      ) : (
        <div className="space-y-3">
          {courses.map((course) => (
            <div key={course.id} className="p-4 border rounded-lg bg-card">
              <div className="flex justify-between items-start">
                <div className="flex-1">
                  <h4 className="font-semibold">{course.title}</h4>
                  <p className="text-sm text-muted-foreground">{course.institute}</p>
                  {course.location && <p className="text-sm text-muted-foreground">{course.location}</p>}
                  {course.start_date && (
                    <p className="text-sm text-muted-foreground mt-1">
                      {new Date(course.start_date).toLocaleDateString()} -{" "}
                      {course.end_date ? new Date(course.end_date).toLocaleDateString() : "Present"}
                    </p>
                  )}
                  {course.resume && <p className="text-sm mt-2">{course.resume}</p>}
                </div>
                <div className="flex gap-2">
                  <Button size="sm" variant="ghost" onClick={() => handleEdit(course)}>
                    <Pencil className="h-4 w-4" />
                  </Button>
                  <Button size="sm" variant="ghost" onClick={() => handleDelete(course.id)}>
                    <Trash2 className="h-4 w-4" />
                  </Button>
                </div>
              </div>
            </div>
          ))}
        </div>
      )}

      <CourseDialog
        open={dialogOpen}
        onOpenChange={setDialogOpen}
        resumeId={resumeId}
        course={editingCourse}
        onSuccess={handleSuccess}
      />
    </div>
  );
}
