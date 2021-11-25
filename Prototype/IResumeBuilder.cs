using System;

namespace Prototype
{
  public  interface IResumeBuilder
    {
        IResumeBuilder BuildBasicInfo(Action<BasicInfo> buildBasicInfoDelegate);
        IResumeBuilder BuildWorkExperience(Action<WorkExperience> buildWorkExperienceDelegate);
        ResumeBase Build();
    }
}
