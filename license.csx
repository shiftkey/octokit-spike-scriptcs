var octokit = Require<OctokitPack>();
var github = octokit.CreateWithBasicAuth("shiftkey-nuke-test-projects", "username", "password");

var repositories = github.Repository.GetAllForCurrent().Result;
foreach (var repository in repositories)
{
   // TODO: "master_branch" doesn't exist, fix this hack later
   // TODO: we could surface the "size" property to see if this repository is empty
   //       for the moment, we throw an exception because reasons

   try
   {
     var response = github.GitDatabase.Tree.Get(repository.Owner.Login, repository.Name, "master").Result;
     var licenseExists = response.Tree.Any(
          t => t.Path.StartsWith("LICENSE")
               && t.Mode == Octokit.FileMode.File);

     if (!licenseExists)
     {
         Console.WriteLine("No license found for " + repository.Name);
     }
   }
   catch (AggregateException ex)
   {
     Console.WriteLine("Skipping due to bad life decisions: " + repository.Name);
   }
}
