import { useEffect, useState } from "react";
import { supabase } from "@/integrations/supabase/client";
import { Button } from "@/components/ui/button";
import { Plus, Pencil, Trash2 } from "lucide-react";
import { useToast } from "@/hooks/use-toast";
import { JobDialog } from "./JobDialog";

interface Job {
  id: string;
  position: string;
  business1: string;
  business2: string;
  start_date: string;
  end_date: string;
  location: string;
  resume: string;
}

export function JobsSection({ resumeId }: { resumeId: string }) {
  const [jobs, setJobs] = useState<Job[]>([]);
  const [loading, setLoading] = useState(true);
  const [dialogOpen, setDialogOpen] = useState(false);
  const [editingJob, setEditingJob] = useState<Job | null>(null);
  const { toast } = useToast();

  useEffect(() => {
    fetchJobs();
  }, [resumeId]);

  const fetchJobs = async () => {
    const { data, error } = await supabase
      .from("jobs")
      .select("*")
      .eq("resume_id", resumeId)
      .order("start_date", { ascending: false });

    if (error) {
      toast({
        variant: "destructive",
        title: "Error",
        description: "Failed to fetch jobs",
      });
    } else {
      setJobs(data || []);
    }
    setLoading(false);
  };

  const handleDelete = async (id: string) => {
    const { error } = await supabase.from("jobs").delete().eq("id", id);

    if (error) {
      toast({
        variant: "destructive",
        title: "Error",
        description: "Failed to delete job",
      });
    } else {
      toast({
        title: "Deleted",
        description: "Job deleted successfully",
      });
      fetchJobs();
    }
  };

  const handleEdit = (job: Job) => {
    setEditingJob(job);
    setDialogOpen(true);
  };

  const handleAdd = () => {
    setEditingJob(null);
    setDialogOpen(true);
  };

  const handleSuccess = () => {
    setDialogOpen(false);
    setEditingJob(null);
    fetchJobs();
  };

  if (loading) {
    return <div>Loading...</div>;
  }

  return (
    <div className="space-y-4">
      <div className="flex justify-between items-center">
        <h3 className="text-lg font-semibold">Work Experience</h3>
        <Button onClick={handleAdd} size="sm">
          <Plus className="h-4 w-4 mr-2" />
          Add Job
        </Button>
      </div>

      {jobs.length === 0 ? (
        <p className="text-muted-foreground text-center py-8">No jobs added yet</p>
      ) : (
        <div className="space-y-3">
          {jobs.map((job) => (
            <div key={job.id} className="p-4 border rounded-lg bg-card">
              <div className="flex justify-between items-start">
                <div className="flex-1">
                  <h4 className="font-semibold">{job.position}</h4>
                  <p className="text-sm text-muted-foreground">{job.business1}</p>
                  {job.business2 && <p className="text-sm text-muted-foreground">{job.business2}</p>}
                  {job.location && <p className="text-sm text-muted-foreground">{job.location}</p>}
                  {job.start_date && (
                    <p className="text-sm text-muted-foreground mt-1">
                      {new Date(job.start_date).toLocaleDateString()} -{" "}
                      {job.end_date ? new Date(job.end_date).toLocaleDateString() : "Present"}
                    </p>
                  )}
                  {job.resume && <p className="text-sm mt-2">{job.resume}</p>}
                </div>
                <div className="flex gap-2">
                  <Button size="sm" variant="ghost" onClick={() => handleEdit(job)}>
                    <Pencil className="h-4 w-4" />
                  </Button>
                  <Button size="sm" variant="ghost" onClick={() => handleDelete(job.id)}>
                    <Trash2 className="h-4 w-4" />
                  </Button>
                </div>
              </div>
            </div>
          ))}
        </div>
      )}

      <JobDialog
        open={dialogOpen}
        onOpenChange={setDialogOpen}
        resumeId={resumeId}
        job={editingJob}
        onSuccess={handleSuccess}
      />
    </div>
  );
}
