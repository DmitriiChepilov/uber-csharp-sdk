using System.ComponentModel;

namespace Uber.SDK.Models
{
	public enum StatusEnum
	{
		[Description("scheduled")]
		Scheduled,

		[Description("processing")]
		Processing,

		[Description("no_couriers_available")]
		NoCouriersAvailable,

		[Description("en_route_to_pickup")]
		EnRouteToPickup,

		[Description("at_pickup")]
		AtPickup,

		[Description("en_route_to_dropoff")]
		EnRouteToDropoff,

		[Description("at_dropoff")]
		AtDropoff,

		[Description("completed")]
		Completed,

		[Description("client_canceled")]
		ClientCanceled,

		[Description("returning")]
		Returning,

		[Description("returned")]
		Returned,

		[Description("unable_to_return")]
		UnableToReturn,

		[Description("unable_to_deliver")]
		UnableToDeliver,

		[Description("unknown")]
		Unknown,

		[Description("")]
		Active
	}
}