using System.Collections.Generic;
using System.Linq;

namespace DotStatic.Core
{
    public class ProjectsData
    {
        private readonly Dictionary<string, HashSet<string>> referencedTypesByProj;
        private readonly Dictionary<string, HashSet<string>> declaredTypesByProj;

        public ProjectsData()
        {
            referencedTypesByProj = new Dictionary<string, HashSet<string>>();
            declaredTypesByProj = new Dictionary<string, HashSet<string>>();
        }

        public IReadOnlyDictionary<string, IEnumerable<string>> ReferencedTypesByProj { get{ return referencedTypesByProj.ToDictionary(a => a.Key, a => a.Value.AsEnumerable()); } }
        public IReadOnlyDictionary<string, IEnumerable<string>> DeclaredTypesByProj { get { return declaredTypesByProj.ToDictionary(a => a.Key, a => a.Value.AsEnumerable()); } }

        public static ProjectsData Merge(ProjectsData p1, ProjectsData p2)
        {
            ProjectsData result = new ProjectsData();
            p1.referencedTypesByProj.ToList().ForEach(x => result.referencedTypesByProj[x.Key] = x.Value);
            p2.referencedTypesByProj.ToList().ForEach(x => result.referencedTypesByProj[x.Key] = x.Value);
            p1.declaredTypesByProj.ToList().ForEach(x => result.declaredTypesByProj[x.Key] = x.Value);
            p2.declaredTypesByProj.ToList().ForEach(x => result.declaredTypesByProj[x.Key] = x.Value);
            return result;
        }

        internal void AddReferencedTypes(string project, IEnumerable<string> typesToAdd)
        {
            HashSet<string> types;
            if (referencedTypesByProj.TryGetValue(project, out types))
            {
                types.UnionWith(typesToAdd);
            }
            else
            {
                referencedTypesByProj[project] = new HashSet<string>(typesToAdd);
            }
        }

        internal void AddDeclaredTypes(string project, IEnumerable<string> typesToAdd)
        {
            HashSet<string> types;
            if (declaredTypesByProj.TryGetValue(project, out types))
            {
                types.UnionWith(typesToAdd);
            }
            else
            {
                declaredTypesByProj[project] = new HashSet<string>(typesToAdd);
            }
        }
    }
}
