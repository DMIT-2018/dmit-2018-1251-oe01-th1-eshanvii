<Query Kind="Statements">
  <Connection>
    <ID>2ac2f3e4-fbe3-4eda-b484-be67c546d466</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Server>.</Server>
    <Database>StartTed-2025-Sept</Database>
    <DriverData>
      <EncryptSqlTraffic>True</EncryptSqlTraffic>
      <PreserveNumeric1>True</PreserveNumeric1>
      <EFProvider>Microsoft.EntityFrameworkCore.SqlServer</EFProvider>
    </DriverData>
  </Connection>
</Query>

//Q1.


ClubActivities
    .ToList()
    .Where(a =>
        a.StartDate >= new DateTime(2025, 1, 1) &&
        (a.CampusVenue.Location != "Scheduled Room") &&
        a.Name != "BTech Club Meeting"
    )
    .Select(a => new {
        StartDate = a.StartDate,
        Location = a.CampusVenue.Location,
        Club = a.Club.ClubName,
        Activity = a.Name
    })
    .OrderBy(a => a.StartDate)
    .Dump();
	
	//Q2.
	
	
	ProgramCourses
		.GroupBy(p => new
		{
			ProgramName = p.Program.ProgramName,
            SchoolCode  = p.Program.SchoolCode
		})
		.Select(a => new {
				School = a.Key.SchoolCode == "SAMIT" 
							? "School of Advance Media and IT"
                    		: a.Key.SchoolCode == "SEET"
                        	? "School of Electrical Engineering Technology"
							: "Unknown",
                Program = a.Key.ProgramName,
                RequiredCoursesCount = a.Count(x => x.Required),
                OptionalCoursesCount = a.Count(x => !x.Required)
		})
		.Where(x => x.RequiredCoursesCount >= 22)
		.OrderBy(x => x.Program)
		.Dump();
	

