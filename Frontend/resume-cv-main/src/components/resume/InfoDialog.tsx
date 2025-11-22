import { useState, useEffect } from "react";
import { supabase } from "@/integrations/supabase/client";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Textarea } from "@/components/ui/textarea";
import { Dialog, DialogContent, DialogHeader, DialogTitle } from "@/components/ui/dialog";
import { useToast } from "@/hooks/use-toast";

interface Info {
  id?: string;
  title: string;
  resume: string;
  url: string;
}

interface InfoDialogProps {
  open: boolean;
  onOpenChange: (open: boolean) => void;
  resumeId: string;
  info: Info | null;
  onSuccess: () => void;
}

export function InfoDialog({ open, onOpenChange, resumeId, info, onSuccess }: InfoDialogProps) {
  const { toast } = useToast();
  const [loading, setLoading] = useState(false);
  const [formData, setFormData] = useState<Info>({
    title: "",
    resume: "",
    url: "",
  });

  useEffect(() => {
    if (info) {
      setFormData(info);
    } else {
      setFormData({
        title: "",
        resume: "",
        url: "",
      });
    }
  }, [info, open]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);

    if (info?.id) {
      const { error } = await supabase
        .from("infos")
        .update(formData)
        .eq("id", info.id);

      if (error) {
        toast({
          variant: "destructive",
          title: "Error",
          description: "Failed to update info",
        });
      } else {
        toast({
          title: "Updated",
          description: "Info updated successfully",
        });
        onSuccess();
      }
    } else {
      const { error } = await supabase
        .from("infos")
        .insert({ ...formData, resume_id: resumeId });

      if (error) {
        toast({
          variant: "destructive",
          title: "Error",
          description: "Failed to create info",
        });
      } else {
        toast({
          title: "Created",
          description: "Info created successfully",
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
          <DialogTitle>{info ? "Edit Info" : "Add Info"}</DialogTitle>
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
          <div className="space-y-2">
            <Label htmlFor="url">URL</Label>
            <Input
              id="url"
              type="url"
              value={formData.url}
              onChange={(e) => setFormData({ ...formData, url: e.target.value })}
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
