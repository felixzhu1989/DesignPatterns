using System;

namespace PrototypeBuilderClone
{
   public interface IResumeBuilder
    {
        IResumeBuilder BuildBasicInfo(Action<BasicInfo> buildBasicInfoDelegate);
        IResumeBuilder BuildWorkExperience(Action<WorkExperience> buildWorkExperienceDelegate);
        ResumeBase Build();
    }
}
