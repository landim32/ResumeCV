import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { supabase } from "@/integrations/supabase/client";
import { Button } from "@/components/ui/button";
import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card";
import { Plus, FileText, Calendar, Trash2, Copy } from "lucide-react";
import { useToast } from "@/hooks/use-toast";
import { SidebarProvider, SidebarTrigger } from "@/components/ui/sidebar";
import { AppSidebar } from "@/components/AppSidebar";

interface Resume {
  id: string;
  title: string;
  name: string;
  email: string;
  phone: string;
  created_at: string;
  updated_at: string;
}

const Dashboard = () => {
  const [resumes, setResumes] = useState<Resume[]>([]);
  const [loading, setLoading] = useState(true);
  const navigate = useNavigate();
  const { toast } = useToast();

  useEffect(() => {
    checkUser();
    fetchResumes();
  }, []);

  const checkUser = async () => {
    const { data: { user } } = await supabase.auth.getUser();
    if (!user) {
      navigate("/login");
    }
  };

  const fetchResumes = async () => {
    const { data, error } = await supabase
      .from("resumes")
      .select("*")
      .order("updated_at", { ascending: false });

    if (error) {
      toast({
        variant: "destructive",
        title: "Error",
        description: "Failed to fetch resumes",
      });
    } else {
      setResumes(data || []);
    }
    setLoading(false);
  };

  const handleDelete = async (id: string) => {
    const { error } = await supabase.from("resumes").delete().eq("id", id);

    if (error) {
      toast({
        variant: "destructive",
        title: "Error",
        description: "Failed to delete resume",
      });
    } else {
      toast({
        title: "Deleted",
        description: "Resume deleted successfully",
      });
      fetchResumes();
    }
  };

  const handleDuplicate = async (resume: Resume) => {
    const { data: { user } } = await supabase.auth.getUser();
    if (!user) return;

    const { data, error } = await supabase
      .from("resumes")
      .insert({
        user_id: user.id,
        title: `${resume.title} (Copy)`,
        name: resume.name,
        email: resume.email,
        phone: resume.phone,
      })
      .select()
      .single();

    if (error) {
      toast({
        variant: "destructive",
        title: "Error",
        description: "Failed to duplicate resume",
      });
    } else {
      toast({
        title: "Duplicated",
        description: "Resume duplicated successfully",
      });
      fetchResumes();
    }
  };

  return (
    <SidebarProvider>
      <div className="flex min-h-screen w-full">
        <AppSidebar />
        <div className="flex-1 flex flex-col">
          <header className="h-16 border-b border-border flex items-center px-6 bg-card">
            <SidebarTrigger />
            <h1 className="text-2xl font-bold ml-4">Dashboard</h1>
          </header>

          <main className="flex-1 p-6 bg-muted/30">
            <div className="max-w-7xl mx-auto">
              <div className="flex justify-between items-center mb-6">
                <div>
                  <h2 className="text-3xl font-bold">My Resumes</h2>
                  <p className="text-muted-foreground mt-1">Manage and create your professional resumes</p>
                </div>
                <Button onClick={() => navigate("/resumes/new")} size="lg" className="shadow-elevation">
                  <Plus className="mr-2 h-5 w-5" />
                  New Resume
                </Button>
              </div>

              {loading ? (
                <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
                  {[1, 2, 3].map((i) => (
                    <Card key={i} className="animate-pulse">
                      <CardHeader>
                        <div className="h-6 bg-muted rounded w-3/4"></div>
                        <div className="h-4 bg-muted rounded w-1/2 mt-2"></div>
                      </CardHeader>
                      <CardContent>
                        <div className="h-4 bg-muted rounded w-full mb-2"></div>
                        <div className="h-4 bg-muted rounded w-2/3"></div>
                      </CardContent>
                    </Card>
                  ))}
                </div>
              ) : resumes.length === 0 ? (
                <Card className="text-center py-12 shadow-elevation">
                  <CardContent>
                    <FileText className="h-16 w-16 mx-auto text-muted-foreground mb-4" />
                    <h3 className="text-xl font-semibold mb-2">No resumes yet</h3>
                    <p className="text-muted-foreground mb-6">
                      Create your first resume to get started
                    </p>
                    <Button onClick={() => navigate("/resumes/new")}>
                      <Plus className="mr-2 h-4 w-4" />
                      Create Resume
                    </Button>
                  </CardContent>
                </Card>
              ) : (
                <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
                  {resumes.map((resume) => (
                    <Card
                      key={resume.id}
                      className="hover:shadow-hover transition-shadow cursor-pointer group"
                      onClick={() => navigate(`/resumes/${resume.id}`)}
                    >
                      <CardHeader>
                        <CardTitle className="flex items-start justify-between">
                          <span className="line-clamp-1">{resume.title}</span>
                          <FileText className="h-5 w-5 text-primary" />
                        </CardTitle>
                        <CardDescription>{resume.name}</CardDescription>
                      </CardHeader>
                      <CardContent>
                        <div className="space-y-2 text-sm text-muted-foreground mb-4">
                          <p>{resume.email}</p>
                          <p className="flex items-center gap-2">
                            <Calendar className="h-4 w-4" />
                            Updated {new Date(resume.updated_at).toLocaleDateString()}
                          </p>
                        </div>
                        <div className="flex gap-2 opacity-0 group-hover:opacity-100 transition-opacity">
                          <Button
                            size="sm"
                            variant="outline"
                            onClick={(e) => {
                              e.stopPropagation();
                              handleDuplicate(resume);
                            }}
                          >
                            <Copy className="h-4 w-4" />
                          </Button>
                          <Button
                            size="sm"
                            variant="destructive"
                            onClick={(e) => {
                              e.stopPropagation();
                              handleDelete(resume.id);
                            }}
                          >
                            <Trash2 className="h-4 w-4" />
                          </Button>
                        </div>
                      </CardContent>
                    </Card>
                  ))}
                </div>
              )}
            </div>
          </main>
        </div>
      </div>
    </SidebarProvider>
  );
};

export default Dashboard;
