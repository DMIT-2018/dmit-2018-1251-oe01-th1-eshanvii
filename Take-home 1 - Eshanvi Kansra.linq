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
	.ToList()
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
	
	
	
	
//Q3.
	
Students
	.Where(s => s.StudentPayments.Count() == 0
				&& s.Countries.CountryName != "Canada")
	.OrderBy(s => s.LastName)
	.Select(s => new
    {
        StudentNumber = s.StudentNumber,
        CountryName   = s.Countries.CountryName,
        FullName      = s.FirstName + " " + s.LastName,
        ClubMembershipCount = (s.ClubMembers.Count() == 0 ? "None" : s.ClubMembers.Count().ToString())
	})
	.Dump();
	
	
	
//Q4.
	
Employees
	.Where(e => e.Position.Description == "Instructor"
				&& e.ReleaseDate == null
            	&& e.ClassOfferings.Count() > 0)
	.OrderByDescending(x => x.ClassOfferings.Count)
	.ThenBy(x => x.LastName)
	.Select(x => new
    {
        ProgramName = x.Program.ProgramName,
        FullName    = x.FirstName + " " + x.LastName,
        WorkLoad    = (x.ClassOfferings.Count > 24 ? "High"
                      : x.ClassOfferings.Count > 8  ? "Med"
                                                    : "Low")
     })
	.Dump();
		
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	

