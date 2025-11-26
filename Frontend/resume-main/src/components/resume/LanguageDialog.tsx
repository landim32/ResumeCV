import { useState, useEffect } from "react";
import { supabase } from "@/integrations/supabase/client";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select";
import { Dialog, DialogContent, DialogHeader, DialogTitle } from "@/components/ui/dialog";
import { useToast } from "@/hooks/use-toast";

interface Language {
  id?: string;
  language: string;
  level: number;
}

interface LanguageDialogProps {
  open: boolean;
  onOpenChange: (open: boolean) => void;
  resumeId: string;
  language: Language | null;
  onSuccess: () => void;
}

const levelOptions = [
  { value: "1", label: "Beginner" },
  { value: "2", label: "Elementary" },
  { value: "3", label: "Intermediate" },
  { value: "4", label: "Advanced" },
  { value: "5", label: "Native" },
];

export function LanguageDialog({ open, onOpenChange, resumeId, language, onSuccess }: LanguageDialogProps) {
  const { toast } = useToast();
  const [loading, setLoading] = useState(false);
  const [formData, setFormData] = useState<Language>({
    language: "",
    level: 3,
  });

  useEffect(() => {
    if (language) {
      setFormData(language);
    } else {
      setFormData({
        language: "",
        level: 3,
      });
    }
  }, [language, open]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);

    if (language?.id) {
      const { error } = await supabase
        .from("languages")
        .update(formData)
        .eq("id", language.id);

      if (error) {
        toast({
          variant: "destructive",
          title: "Error",
          description: "Failed to update language",
        });
      } else {
        toast({
          title: "Updated",
          description: "Language updated successfully",
        });
        onSuccess();
      }
    } else {
      const { error } = await supabase
        .from("languages")
        .insert({ ...formData, resume_id: resumeId });

      if (error) {
        toast({
          variant: "destructive",
          title: "Error",
          description: "Failed to create language",
        });
      } else {
        toast({
          title: "Created",
          description: "Language created successfully",
        });
        onSuccess();
      }
    }

    setLoading(false);
  };

  return (
    <Dialog open={open} onOpenChange={onOpenChange}>
      <DialogContent className="max-w-md">
        <DialogHeader>
          <DialogTitle>{language ? "Edit Language" : "Add Language"}</DialogTitle>
        </DialogHeader>
        <form onSubmit={handleSubmit} className="space-y-4">
          <div className="space-y-2">
            <Label htmlFor="language">Language *</Label>
            <Input
              id="language"
              value={formData.language}
              onChange={(e) => setFormData({ ...formData, language: e.target.value })}
              required
            />
          </div>
          <div className="space-y-2">
            <Label htmlFor="level">Proficiency Level *</Label>
            <Select
              value={formData.level.toString()}
              onValueChange={(value) => setFormData({ ...formData, level: parseInt(value) })}
            >
              <SelectTrigger>
                <SelectValue />
              </SelectTrigger>
              <SelectContent>
                {levelOptions.map((option) => (
                  <SelectItem key={option.value} value={option.value}>
                    {option.label}
                  </SelectItem>
                ))}
              </SelectContent>
            </Select>
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
