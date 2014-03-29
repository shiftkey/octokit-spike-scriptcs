var octokit = Require<OctokitPack>();
var github = octokit.CreateWithBasicAuth("shiftkey-nuke-test-projects", "shiftkey-tester", "e6myQ3ZbaMLU451URaobrXKHC6b0PR1qvHYE");

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
