import { useEffect, useState } from "react";
import { supabase } from "@/integrations/supabase/client";
import { Button } from "@/components/ui/button";
import { Plus, Pencil, Trash2 } from "lucide-react";
import { useToast } from "@/hooks/use-toast";
import { InfoDialog } from "./InfoDialog";

interface Info {
  id: string;
  title: string;
  resume: string;
  url: string;
}

export function InfosSection({ resumeId }: { resumeId: string }) {
  const [infos, setInfos] = useState<Info[]>([]);
  const [loading, setLoading] = useState(true);
  const [dialogOpen, setDialogOpen] = useState(false);
  const [editingInfo, setEditingInfo] = useState<Info | null>(null);
  const { toast } = useToast();

  useEffect(() => {
    fetchInfos();
  }, [resumeId]);

  const fetchInfos = async () => {
    const { data, error } = await supabase
      .from("infos")
      .select("*")
      .eq("resume_id", resumeId);

    if (error) {
      toast({
        variant: "destructive",
        title: "Error",
        description: "Failed to fetch infos",
      });
    } else {
      setInfos(data || []);
    }
    setLoading(false);
  };

  const handleDelete = async (id: string) => {
    const { error } = await supabase.from("infos").delete().eq("id", id);

    if (error) {
      toast({
        variant: "destructive",
        title: "Error",
        description: "Failed to delete info",
      });
    } else {
      toast({
        title: "Deleted",
        description: "Info deleted successfully",
      });
      fetchInfos();
    }
  };

  const handleEdit = (info: Info) => {
    setEditingInfo(info);
    setDialogOpen(true);
  };

  const handleAdd = () => {
    setEditingInfo(null);
    setDialogOpen(true);
  };

  const handleSuccess = () => {
    setDialogOpen(false);
    setEditingInfo(null);
    fetchInfos();
  };

  if (loading) {
    return <div>Loading...</div>;
  }

  return (
    <div className="space-y-4">
      <div className="flex justify-between items-center">
        <h3 className="text-lg font-semibold">Additional Information</h3>
        <Button onClick={handleAdd} size="sm">
          <Plus className="h-4 w-4 mr-2" />
          Add Info
        </Button>
      </div>

      {infos.length === 0 ? (
        <p className="text-muted-foreground text-center py-8">No info added yet</p>
      ) : (
        <div className="space-y-3">
          {infos.map((info) => (
            <div key={info.id} className="p-4 border rounded-lg bg-card">
              <div className="flex justify-between items-start">
                <div className="flex-1">
                  <h4 className="font-semibold">{info.title}</h4>
                  {info.url && (
                    <a
                      href={info.url}
                      target="_blank"
                      rel="noopener noreferrer"
                      className="text-sm text-primary hover:underline"
                    >
                      {info.url}
                    </a>
                  )}
                  {info.resume && <p className="text-sm mt-2">{info.resume}</p>}
                </div>
                <div className="flex gap-2">
                  <Button size="sm" variant="ghost" onClick={() => handleEdit(info)}>
                    <Pencil className="h-4 w-4" />
                  </Button>
                  <Button size="sm" variant="ghost" onClick={() => handleDelete(info.id)}>
                    <Trash2 className="h-4 w-4" />
                  </Button>
                </div>
              </div>
            </div>
          ))}
        </div>
      )}

      <InfoDialog
        open={dialogOpen}
        onOpenChange={setDialogOpen}
        resumeId={resumeId}
        info={editingInfo}
        onSuccess={handleSuccess}
      />
    </div>
  );
}
