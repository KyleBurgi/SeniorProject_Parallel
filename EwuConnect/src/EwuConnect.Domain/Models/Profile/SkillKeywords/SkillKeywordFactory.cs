using System;
namespace EwuConnect.Domain.Models.Profile.SkillKeywords
{   
    public abstract class SkillKeyword
    {
        public abstract string Title { get; } 
    }

    public class Business : SkillKeyword
    {
        public override string Title
        {
            get
            {
                return "Business";
            }
        }
    }
    public class ComputerScience : SkillKeyword
    {
        public override string Title
        {
            get
            {
                return "Computer Science";
            }
        }
    }

    public class Murder : SkillKeyword
    {
        public override string Title
        {
            get
            {
                return "Murder";
            }
        }
    }
}
