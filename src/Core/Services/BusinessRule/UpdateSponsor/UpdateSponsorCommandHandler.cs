using CodeCampServer.Core.Domain;
using CodeCampServer.Core.Domain.Model;

namespace CodeCampServer.Core.Services.BusinessRule.UpdateSponsor
{
	public class UpdateSponsorCommandHandler : ICommand<UpdateSponsorCommandMessage, Sponsor>
	{
		private readonly ISponsorRepository _repository;

		public UpdateSponsorCommandHandler(ISponsorRepository repository)
		{
			_repository = repository;
		}

		public Sponsor Execute(UpdateSponsorCommandMessage commandMessage)
		{
			Sponsor sponsor = commandMessage.Id ?? new Sponsor(){UserGroup = commandMessage.UserGroup};
			sponsor.Level = commandMessage.Level;
			sponsor.BannerUrl = commandMessage.BannerUrl;
			sponsor.Name = commandMessage.Name;
			sponsor.Url = commandMessage.Url;

			_repository.Save(sponsor);
			return sponsor;
		}
	}
}