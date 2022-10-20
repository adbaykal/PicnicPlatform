namespace PicnicMicroservice.Infrastructure.Persistence
{
    public static class ApplicationDBContextSeed
    {
        public static async Task SeedSampleDataAsync(ApplicationDBContext context)
        {
            // Seed, if necessary
            if (!context.Picnics.Any())
            {
                for (int i = 0; i < 10; i++)
                {
                    var picnicId = Guid.NewGuid();
                    context.Picnics.Add(new Domain.Entities.Picnic
                    {
                        PicnicId = picnicId,
                        Description = $"Picnic {picnicId}",
                        LocationLat = (decimal)28.323,
                        LocationLong = (decimal)1.45645,
                        MemberId = Guid.NewGuid(),
                        PicnicType = Domain.Enums.PicnicType.Private
                    });
                }


                await context.SaveChangesAsync();
            }
        }
    }
}
