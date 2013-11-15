var octokit = Require<OctokitPack>();
var github = octokit.CreateWithBasicAuth("shiftkey-nuke-test-projects", "username", "password");

var repositories = github.Repository.GetAllForCurrent().Result;
foreach (var repository in repositories)
{
   if (repository.Name.StartsWith("public-repo-"))
   {
       Console.WriteLine("Deleting repository {0}/{1}", repository.Owner.Login, repository.Name);
       github.Repository.Delete(repository.Owner.Login, repository.Name).Wait();
   }
   else
   {
       Console.WriteLine("skipping repository " + repository.Name);
   }
}