#r System.Net.Http

using Octokit;
using System.Net.Http.Headers;

var github = new GitHubClient(new ProductHeaderValue("shiftkey-nuke-test-projects"))
{
  Credentials = new Credentials("username", "password")
};

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