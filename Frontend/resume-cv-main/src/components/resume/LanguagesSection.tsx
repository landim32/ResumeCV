import { useEffect, useState } from "react";
import { supabase } from "@/integrations/supabase/client";
import { Button } from "@/components/ui/button";
import { Plus, Pencil, Trash2 } from "lucide-react";
import { useToast } from "@/hooks/use-toast";
import { LanguageDialog } from "./LanguageDialog";

interface Language {
  id: string;
  language: string;
  level: number;
}

const levelLabels: { [key: number]: string } = {
  1: "Beginner",
  2: "Elementary",
  3: "Intermediate",
  4: "Advanced",
  5: "Native",
};

export function LanguagesSection({ resumeId }: { resumeId: string }) {
  const [languages, setLanguages] = useState<Language[]>([]);
  const [loading, setLoading] = useState(true);
  const [dialogOpen, setDialogOpen] = useState(false);
  const [editingLanguage, setEditingLanguage] = useState<Language | null>(null);
  const { toast } = useToast();

  useEffect(() => {
    fetchLanguages();
  }, [resumeId]);

  const fetchLanguages = async () => {
    const { data, error } = await supabase
      .from("languages")
      .select("*")
      .eq("resume_id", resumeId)
      .order("level", { ascending: false });

    if (error) {
      toast({
        variant: "destructive",
        title: "Error",
        description: "Failed to fetch languages",
      });
    } else {
      setLanguages(data || []);
    }
    setLoading(false);
  };

  const handleDelete = async (id: string) => {
    const { error } = await supabase.from("languages").delete().eq("id", id);

    if (error) {
      toast({
        variant: "destructive",
        title: "Error",
        description: "Failed to delete language",
      });
    } else {
      toast({
        title: "Deleted",
        description: "Language deleted successfully",
      });
      fetchLanguages();
    }
  };

  const handleEdit = (language: Language) => {
    setEditingLanguage(language);
    setDialogOpen(true);
  };

  const handleAdd = () => {
    setEditingLanguage(null);
    setDialogOpen(true);
  };

  const handleSuccess = () => {
    setDialogOpen(false);
    setEditingLanguage(null);
    fetchLanguages();
  };

  if (loading) {
    return <div>Loading...</div>;
  }

  return (
    <div className="space-y-4">
      <div className="flex justify-between items-center">
        <h3 className="text-lg font-semibold">Languages</h3>
        <Button onClick={handleAdd} size="sm">
          <Plus className="h-4 w-4 mr-2" />
          Add Language
        </Button>
      </div>

      {languages.length === 0 ? (
        <p className="text-muted-foreground text-center py-8">No languages added yet</p>
      ) : (
        <div className="space-y-3">
          {languages.map((language) => (
            <div key={language.id} className="p-4 border rounded-lg bg-card">
              <div className="flex justify-between items-center">
                <div>
                  <h4 className="font-semibold">{language.language}</h4>
                  <p className="text-sm text-muted-foreground">
                    {levelLabels[language.level] || `Level ${language.level}`}
                  </p>
                </div>
                <div className="flex gap-2">
                  <Button size="sm" variant="ghost" onClick={() => handleEdit(language)}>
                    <Pencil className="h-4 w-4" />
                  </Button>
                  <Button size="sm" variant="ghost" onClick={() => handleDelete(language.id)}>
                    <Trash2 className="h-4 w-4" />
                  </Button>
                </div>
              </div>
            </div>
          ))}
        </div>
      )}

      <LanguageDialog
        open={dialogOpen}
        onOpenChange={setDialogOpen}
        resumeId={resumeId}
        language={editingLanguage}
        onSuccess={handleSuccess}
      />
    </div>
  );
}
