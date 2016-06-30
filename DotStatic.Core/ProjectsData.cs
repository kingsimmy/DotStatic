using System.Collections.Generic;
using System.Linq;

namespace DotStatic.Core
{
    public class ProjectsData
    {
        private readonly Dictionary<string, List<string>> referencedTypesByProj;
        private readonly Dictionary<string, List<string>> declaredTypesByProj;

        public ProjectsData()
        {
            referencedTypesByProj = new Dictionary<string, List<string>>();
            declaredTypesByProj = new Dictionary<string, List<string>>();
        }

        public IReadOnlyDictionary<string, List<string>> ReferencedTypesByProj { get{ return referencedTypesByProj;} }
        public IReadOnlyDictionary<string, List<string>> DeclaredTypesByProj { get { return declaredTypesByProj; } }

        internal void AddReferencedTypes(string project, IEnumerable<string> typesToAdd)
        {
            List<string> types;
            if (referencedTypesByProj.TryGetValue(project, out types))
            {
                types.AddRange(types);
            }
            else
            {
                referencedTypesByProj[project] = typesToAdd.ToList();
            }
        }

        internal void AddDeclaredTypes(string project, IEnumerable<string> typesToAdd)
        {
            List<string> types;
            if (declaredTypesByProj.TryGetValue(project, out types))
            {
                types.AddRange(types);
            }
            else
            {
                declaredTypesByProj[project] = typesToAdd.ToList();
            }
        }
    }
}
