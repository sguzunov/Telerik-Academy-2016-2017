using System.Collections.Generic;

namespace Dealership.Models.Contracts
{
    public interface ICommentable
    {
        IList<IComment> Comments { get; }
    }
}
