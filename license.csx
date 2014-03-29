var octokit = Require<OctokitPack>();
var github = octokit.CreateWithBasicAuth("shiftkey-nuke-test-projects", "username", "password");

var repositories = github.Repository.GetAllForCurrent().Result;
foreach (var repository in repositories)
{
   Console.WriteLine("Checking repository: " + repository.Name);

   var tree = github.GitDatabase.Tree.Get(repository.Owner.Login, repository.Name, repository.MasterBranch);

   if (false)
   {
     // hey, the repo doesn't have a LICENSE file at the root!
   }
}
