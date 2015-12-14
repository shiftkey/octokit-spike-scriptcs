var octokit = Require<OctokitPack>();

var username = System.Environment.GetEnvironmentVariable("OCTOKIT_GITHUBUSERNAME");
var password = System.Environment.GetEnvironmentVariable("OCTOKIT_GITHUBPASSWORD");

var github = octokit.CreateWithBasicAuth("shiftkey-nuke-test-projects", username, password);

var repositories = github.Repository.GetAllForCurrent().Result;
foreach (var repository in repositories)
{
   var name = repository.Name;
   if (name.StartsWith("public-repo-")
		|| name.StartsWith("repo-to-delete-")
		|| name.StartsWith("repo-with-")
		|| name.StartsWith("repo-without-")
		|| name.StartsWith("private-repo-")
		|| name.StartsWith("source-repo-")
		|| name.StartsWith("existing-repo-"))
   {
       var login = repository.Owner.Login;
       Console.WriteLine("Deleting repository {0}/{1}", login, name);
       github.Repository.Delete(login, name).Wait();
   }
   else
   {
       Console.WriteLine("skipping repository " + repository.Name);
   }
}