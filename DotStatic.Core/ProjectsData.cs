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
