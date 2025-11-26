import { useState, useEffect } from "react";
import { supabase } from "@/integrations/supabase/client";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Textarea } from "@/components/ui/textarea";
import { Dialog, DialogContent, DialogHeader, DialogTitle } from "@/components/ui/dialog";
import { useToast } from "@/hooks/use-toast";

interface Job {
  id?: string;
  position: string;
  business1: string;
  business2: string;
  start_date: string;
  end_date: string;
  location: string;
  resume: string;
}

interface JobDialogProps {
  open: boolean;
  onOpenChange: (open: boolean) => void;
  resumeId: string;
  job: Job | null;
  onSuccess: () => void;
}

export function JobDialog({ open, onOpenChange, resumeId, job, onSuccess }: JobDialogProps) {
  const { toast } = useToast();
  const [loading, setLoading] = useState(false);
  const [formData, setFormData] = useState<Job>({
    position: "",
    business1: "",
    business2: "",
    start_date: "",
    end_date: "",
    location: "",
    resume: "",
  });

  useEffect(() => {
    if (job) {
      setFormData(job);
    } else {
      setFormData({
        position: "",
        business1: "",
        business2: "",
        start_date: "",
        end_date: "",
        location: "",
        resume: "",
      });
    }
  }, [job, open]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);

    if (job?.id) {
      const { error } = await supabase
        .from("jobs")
        .update(formData)
        .eq("id", job.id);

      if (error) {
        toast({
          variant: "destructive",
          title: "Error",
          description: "Failed to update job",
        });
      } else {
        toast({
          title: "Updated",
          description: "Job updated successfully",
        });
        onSuccess();
      }
    } else {
      const { error } = await supabase
        .from("jobs")
        .insert({ ...formData, resume_id: resumeId });

      if (error) {
        toast({
          variant: "destructive",
          title: "Error",
          description: "Failed to create job",
        });
      } else {
        toast({
          title: "Created",
          description: "Job created successfully",
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
          <DialogTitle>{job ? "Edit Job" : "Add Job"}</DialogTitle>
        </DialogHeader>
        <form onSubmit={handleSubmit} className="space-y-4">
          <div className="space-y-2">
            <Label htmlFor="position">Position *</Label>
            <Input
              id="position"
              value={formData.position}
              onChange={(e) => setFormData({ ...formData, position: e.target.value })}
              required
            />
          </div>
          <div className="grid grid-cols-2 gap-4">
            <div className="space-y-2">
              <Label htmlFor="business1">Company</Label>
              <Input
                id="business1"
                value={formData.business1}
                onChange={(e) => setFormData({ ...formData, business1: e.target.value })}
              />
            </div>
            <div className="space-y-2">
              <Label htmlFor="business2">Department</Label>
              <Input
                id="business2"
                value={formData.business2}
                onChange={(e) => setFormData({ ...formData, business2: e.target.value })}
              />
            </div>
          </div>
          <div className="space-y-2">
            <Label htmlFor="location">Location</Label>
            <Input
              id="location"
              value={formData.location}
              onChange={(e) => setFormData({ ...formData, location: e.target.value })}
            />
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
