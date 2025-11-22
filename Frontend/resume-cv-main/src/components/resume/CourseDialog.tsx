import { useState, useEffect } from "react";
import { supabase } from "@/integrations/supabase/client";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Textarea } from "@/components/ui/textarea";
import { Dialog, DialogContent, DialogHeader, DialogTitle } from "@/components/ui/dialog";
import { useToast } from "@/hooks/use-toast";

interface Course {
  id?: string;
  course_type: number;
  title: string;
  location: string;
  institute: string;
  resume: string;
  start_date: string;
  end_date: string;
}

interface CourseDialogProps {
  open: boolean;
  onOpenChange: (open: boolean) => void;
  resumeId: string;
  course: Course | null;
  onSuccess: () => void;
}

export function CourseDialog({ open, onOpenChange, resumeId, course, onSuccess }: CourseDialogProps) {
  const { toast } = useToast();
  const [loading, setLoading] = useState(false);
  const [formData, setFormData] = useState<Course>({
    course_type: 1,
    title: "",
    location: "",
    institute: "",
    resume: "",
    start_date: "",
    end_date: "",
  });

  useEffect(() => {
    if (course) {
      setFormData(course);
    } else {
      setFormData({
        course_type: 1,
        title: "",
        location: "",
        institute: "",
        resume: "",
        start_date: "",
        end_date: "",
      });
    }
  }, [course, open]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);

    if (course?.id) {
      const { error } = await supabase
        .from("courses")
        .update(formData)
        .eq("id", course.id);

      if (error) {
        toast({
          variant: "destructive",
          title: "Error",
          description: "Failed to update course",
        });
      } else {
        toast({
          title: "Updated",
          description: "Course updated successfully",
        });
        onSuccess();
      }
    } else {
      const { error } = await supabase
        .from("courses")
        .insert({ ...formData, resume_id: resumeId });

      if (error) {
        toast({
          variant: "destructive",
          title: "Error",
          description: "Failed to create course",
        });
      } else {
        toast({
          title: "Created",
          description: "Course created successfully",
        });
        onSuccess();
      }
    }

    setLoading(false);
  };

  return (
    <Dialog open={open} onOpenChange={onOpenChange}>
      <DialogContent className="max-w-2xl max-h-[90vh] overflow-y-auto">
        <DialogHeader>
          <DialogTitle>{course ? "Edit Course" : "Add Course"}</DialogTitle>
        </DialogHeader>
        <form onSubmit={handleSubmit} className="space-y-4">
          <div className="space-y-2">
            <Label htmlFor="title">Title *</Label>
            <Input
              id="title"
              value={formData.title}
              onChange={(e) => setFormData({ ...formData, title: e.target.value })}
              required
            />
          </div>
          <div className="grid grid-cols-2 gap-4">
            <div className="space-y-2">
              <Label htmlFor="institute">Institute</Label>
              <Input
                id="institute"
                value={formData.institute}
                onChange={(e) => setFormData({ ...formData, institute: e.target.value })}
              />
            </div>
            <div className="space-y-2">
              <Label htmlFor="location">Location</Label>
              <Input
                id="location"
                value={formData.location}
                onChange={(e) => setFormData({ ...formData, location: e.target.value })}
              />
            </div>
          </div>
          <div className="grid grid-cols-2 gap-4">
            <div className="space-y-2">
              <Label htmlFor="start_date">Start Date</Label>
              <Input
                id="start_date"
                type="date"
                value={formData.start_date?.split("T")[0] || ""}
                onChange={(e) => setFormData({ ...formData, start_date: e.target.value })}
              />
            </div>
            <div className="space-y-2">
              <Label htmlFor="end_date">End Date</Label>
              <Input
                id="end_date"
                type="date"
                value={formData.end_date?.split("T")[0] || ""}
                onChange={(e) => setFormData({ ...formData, end_date: e.target.value })}
              />
            </div>
          </div>
          <div className="space-y-2">
            <Label htmlFor="course_type">Course Type</Label>
            <Input
              id="course_type"
              type="number"
              value={formData.course_type}
              onChange={(e) => setFormData({ ...formData, course_type: parseInt(e.target.value) })}
            />
          </div>
          <div className="space-y-2">
            <Label htmlFor="resume">Description</Label>
            <Textarea
              id="resume"
              value={formData.resume}
              onChange={(e) => setFormData({ ...formData, resume: e.target.value })}
              rows={3}
            />
          </div>
          <div className="flex justify-end gap-2">
            <Button type="button" variant="outline" onClick={() => onOpenChange(false)}>
              Cancel
            </Button>
            <Button type="submit" disabled={loading}>
              {loading ? "Saving..." : "Save"}
            </Button>
          </div>
        </form>
      </DialogContent>
    </Dialog>
  );
}
