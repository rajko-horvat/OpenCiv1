namespace OpenCiv1
{
	public enum MenuBoxReportTypeEnum
	{
		/// <summary>
		/// No title or image
		/// </summary>
		None = -1,
		/// <summary>
		/// Message box title: 'Spies report:', spy image on the left
		/// </summary>
		SpiesReport = 0,
		/// <summary>
		/// Message box title: 'Diplomats report:', diplomat image on the left
		/// </summary>
		DiplomatsReport = 1,
		/// <summary>
		/// Message box title: 'Travelers report:', image of two men with a cup of beer on the left
		/// </summary>
		TravelersReport = 2,
		/// <summary>
		/// Message box title: 'Defense Minister:', minister image on the left
		/// </summary>
		DefenseMinisterReport = 3,
		/// <summary>
		/// Message box title: 'Domestic Advisor:', advisor image on the left
		/// </summary>
		DomesticAdvisorReport = 4,
		/// <summary>
		/// Message box title: 'Foreign Minister:', minister image on the left
		/// </summary>
		ForeignMinisterReport = 5,
		/// <summary>
		/// Message box title: 'Science Advisor:', advisor image on the left
		/// </summary>
		ScienceAdvisorReport = 6
	}
}
