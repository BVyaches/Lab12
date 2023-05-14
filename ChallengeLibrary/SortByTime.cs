using System.Collections;
using System.Diagnostics.CodeAnalysis;


namespace ChallengeLibrary
{
    [ExcludeFromCodeCoverage]
    public class SortByTime: IComparer
    {
        int IComparer.Compare(object first, object second)
        {
            Challenge challenge1 = (Challenge)first;
            Challenge challenge2 = (Challenge)second;
            return challenge1.TimeToPass - challenge2.TimeToPass;
        }
    }
}
