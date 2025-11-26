import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { supabase } from "@/integrations/supabase/client";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Textarea } from "@/components/ui/textarea";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/components/ui/tabs";
import { useToast } from "@/hooks/use-toast";
import { SidebarProvider, SidebarTrigger } from "@/components/ui/sidebar";
import { AppSidebar } from "@/components/AppSidebar";
import { Save, Download, Copy, ArrowLeft } from "lucide-react";
import { CoursesSection } from "@/components/resume/CoursesSection";
import { JobsSection } from "@/components/resume/JobsSection";
import { InfosSection } from "@/components/resume/InfosSection";
import { LanguagesSection } from "@/components/resume/LanguagesSection";

interface ResumeData {
  id?: string;
  title: string;
  name: string;
  phone: string;
  email: string;
  address: string;
  resume: string;
  status: number;
}

const ResumeEditor = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const { toast } = useToast();
  const [loading, setLoading] = useState(true);
  const [saving, setSaving] = useState(false);
  const [resumeData, setResumeData] = useState<ResumeData>({
    title: "",
    name: "",
    phone: "",
    email: "",
    address: "",
    resume: "",
    status: 1,
  });

  useEffect(() => {
    checkUser();
    if (id && id !== "new") {
      fetchResume();
    } else {
      setLoading(false);
    }
  }, [id]);

  const checkUser = async () => {
    const { data: { user } } = await supabase.auth.getUser();
    if (!user) {
      navigate("/login");
    }
  };

  const fetchResume = async () => {
    if (!id) return;

    const { data, error } = await supabase
      .from("resumes")
      .select("*")
      .eq("id", id)
      .single();

    if (error) {
      toast({
        variant: "destructive",
        title: "Error",
        description: "Failed to fetch resume",
      });
      navigate("/dashboard");
    } else {
      setResumeData(data);
    }
    setLoading(false);
  };

  const handleSave = async () => {
    setSaving(true);
    const { data: { user } } = await supabase.auth.getUser();
    if (!user) return;

    if (id && id !== "new") {
      const { error } = await supabase
        .from("resumes")
        .update(resumeData)
        .eq("id", id);

      if (error) {
        toast({
          variant: "destructive",
          title: "Error",
          description: "Failed to update resume",
        });
      } else {
        toast({
          title: "Saved",
          description: "Resume updated successfully",
        });
      }
    } else {
      const { data, error } = await supabase
        .from("resumes")
        .insert({ ...resumeData, user_id: user.id })
        .select()
        .single();

      if (error) {
        toast({
          variant: "destructive",
          title: "Error",
          description: "Failed to create resume",
        });
      } else {
        toast({
          title: "Created",
          description: "Resume created successfully",
        });
        navigate(`/resumes/${data.id}`);
      }
    }
    setSaving(false);
  };

  const handleCopyJSON = async () => {
    if (!id || id === "new") {
      toast({
        variant: "destructive",
        title: "Error",
        description: "Please save the resume first",
      });
      return;
    }

    try {
      const { data: courses } = await supabase
        .from("courses")
        .select("*, course_skills(skill_id, skills(slug, name))")
        .eq("resume_id", id);

      const { data: infos } = await supabase
        .from("infos")
        .select("*, info_skills(skill_id, skills(slug, name))")
        .eq("resume_id", id);

      const { data: jobs } = await supabase
        .from("jobs")
        .select("*, job_skills(skill_id, skills(slug, name))")
        .eq("resume_id", id);

      const { data: languages } = await supabase
        .from("languages")
        .select("*")
        .eq("resume_id", id);

      const fullResume = {
        ...resumeData,
        resumeId: id,
        courses: courses?.map(c => ({
          ...c,
          skills: c.course_skills?.map((cs: any) => cs.skills) || []
        })) || [],
        infos: infos?.map(i => ({
          ...i,
          skills: i.info_skills?.map((is: any) => is.skills) || []
        })) || [],
        jobs: jobs?.map(j => ({
          ...j,
          skills: j.job_skills?.map((js: any) => js.skills) || []
        })) || [],
        languages: languages || [],
      };

      await navigator.clipboard.writeText(JSON.stringify(fullResume, null, 2));
      toast({
        title: "Copied!",
        description: "Resume JSON copied to clipboard",
      });
    } catch (error) {
      toast({
        variant: "destructive",
        title: "Error",
        description: "Failed to copy JSON",
      });
    }
  };

  const handleDownloadJSON = async () => {
    if (!id || id === "new") {
      toast({
        variant: "destructive",
        title: "Error",
        description: "Please save the resume first",
      });
      return;
    }

    try {
      const { data: courses } = await supabase
        .from("courses")
        .select("*, course_skills(skill_id, skills(slug, name))")
        .eq("resume_id", id);

      const { data: infos } = await supabase
        .from("infos")
        .select("*, info_skills(skill_id, skills(slug, name))")
        .eq("resume_id", id);

      const { data: jobs } = await supabase
        .from("jobs")
        .select("*, job_skills(skill_id, skills(slug, name))")
        .eq("resume_id", id);

      const { data: languages } = await supabase
        .from("languages")
        .select("*")
        .eq("resume_id", id);

      const fullResume = {
        ...resumeData,
        resumeId: id,
        courses: courses?.map(c => ({
          ...c,
          skills: c.course_skills?.map((cs: any) => cs.skills) || []
        })) || [],
        infos: infos?.map(i => ({
          ...i,
          skills: i.info_skills?.map((is: any) => is.skills) || []
        })) || [],
        jobs: jobs?.map(j => ({
          ...j,
          skills: j.job_skills?.map((js: any) => js.skills) || []
        })) || [],
        languages: languages || [],
      };

      const blob = new Blob([JSON.stringify(fullResume, null, 2)], { type: "application/json" });
      const url = URL.createObjectURL(blob);
      const a = document.createElement("a");
      a.href = url;
      a.download = `${resumeData.title || 'resume'}.json`;
      a.click();
      URL.revokeObjectURL(url);

      toast({
        title: "Downloaded!",
        description: "Resume JSON downloaded successfully",
      });
    } catch (error) {
      toast({
        variant: "destructive",
        title: "Error",
        description: "Failed to download JSON",
      });
    }
  };

  if (loading) {
    return (
      <div className="min-h-screen flex items-center justify-center">
        <div className="animate-spin rounded-full h-12 w-12 border-b-2 border-primary"></div>
      </div>
    );
  }

  return (
    <SidebarProvider>
      <div className="flex min-h-screen w-full">
        <AppSidebar />
        <div className="flex-1 flex flex-col">
          <header className="h-16 border-b border-border flex items-center justify-between px-6 bg-card">
            <div className="flex items-center gap-4">
              <SidebarTrigger />
              <Button variant="ghost" size="sm" onClick={() => navigate("/dashboard")}>
                <ArrowLeft className="h-4 w-4 mr-2" />
                Back
              </Button>
              <h1 className="text-xl font-bold">
                {id === "new" ? "New Resume" : "Edit Resume"}
              </h1>
            </div>
            <div className="flex gap-2">
              {id !== "new" && (
                <>
                  <Button variant="outline" size="sm" onClick={handleCopyJSON}>
                    <Copy className="h-4 w-4 mr-2" />
                    Copy JSON
                  </Button>
                  <Button variant="outline" size="sm" onClick={handleDownloadJSON}>
                    <Download className="h-4 w-4 mr-2" />
                    Download JSON
                  </Button>
                </>
              )}
              <Button onClick={handleSave} disabled={saving}>
                <Save className="h-4 w-4 mr-2" />
                {saving ? "Saving..." : "Save"}
              </Button>
            </div>
          </header>

          <main className="flex-1 p-6 bg-muted/30 overflow-auto">
            <div className="max-w-5xl mx-auto space-y-6">
              <Card className="shadow-elevation">
                <CardHeader>
                  <CardTitle>Basic Information</CardTitle>
                </CardHeader>
                <CardContent className="space-y-4">
                  <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
                    <div className="space-y-2">
                      <Label htmlFor="title">Resume Title *</Label>
                      <Input
                        id="title"
                        value={resumeData.title}
                        onChange={(e) => setResumeData({ ...resumeData, title: e.target.value })}
                        required
                      />
                    </div>
                    <div className="space-y-2">
                      <Label htmlFor="name">Full Name *</Label>
                      <Input
                        id="name"
                        value={resumeData.name}
                        onChange={(e) => setResumeData({ ...resumeData, name: e.target.value })}
                        required
                      />
                    </div>
                    <div className="space-y-2">
                      <Label htmlFor="email">Email</Label>
                      <Input
                        id="email"
                        type="email"
                        value={resumeData.email}
                        onChange={(e) => setResumeData({ ...resumeData, email: e.target.value })}
                      />
                    </div>
                    <div className="space-y-2">
                      <Label htmlFor="phone">Phone</Label>
                      <Input
                        id="phone"
                        value={resumeData.phone}
                        onChange={(e) => setResumeData({ ...resumeData, phone: e.target.value })}
                      />
                    </div>
                  </div>
                  <div className="space-y-2">
                    <Label htmlFor="address">Address</Label>
                    <Input
                      id="address"
                      value={resumeData.address}
                      onChange={(e) => setResumeData({ ...resumeData, address: e.target.value })}
                    />
                  </div>
                  <div className="space-y-2">
                    <Label htmlFor="resume">Summary</Label>
                    <Textarea
                      id="resume"
                      value={resumeData.resume}
                      onChange={(e) => setResumeData({ ...resumeData, resume: e.target.value })}
                      rows={4}
                    />
                  </div>
                </CardContent>
              </Card>

              {id && id !== "new" && (
                <Card className="shadow-elevation">
                  <CardHeader>
                    <CardTitle>Resume Sections</CardTitle>
                  </CardHeader>
                  <CardContent>
                    <Tabs defaultValue="courses" className="w-full">
                      <TabsList className="grid w-full grid-cols-4">
                        <TabsTrigger value="courses">Courses</TabsTrigger>
                        <TabsTrigger value="jobs">Jobs</TabsTrigger>
                        <TabsTrigger value="infos">Info</TabsTrigger>
                        <TabsTrigger value="languages">Languages</TabsTrigger>
                      </TabsList>
                      <TabsContent value="courses" className="mt-6">
                        <CoursesSection resumeId={id} />
                      </TabsContent>
                      <TabsContent value="jobs" className="mt-6">
                        <JobsSection resumeId={id} />
                      </TabsContent>
                      <TabsContent value="infos" className="mt-6">
                        <InfosSection resumeId={id} />
                      </TabsContent>
                      <TabsContent value="languages" className="mt-6">
                        <LanguagesSection resumeId={id} />
                      </TabsContent>
                    </Tabs>
                  </CardContent>
                </Card>
              )}
            </div>
          </main>
        </div>
      </div>
    </SidebarProvider>
  );
};

export default ResumeEditor;
