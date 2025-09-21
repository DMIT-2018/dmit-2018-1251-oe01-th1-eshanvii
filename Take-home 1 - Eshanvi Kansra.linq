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
        a.StartDate,
        Location = a.CampusVenue.Location ?? "N/A",
        Club = a.Club.ClubName,
        Activity = a.Name
    })
    .OrderBy(a => a.StartDate)
    .Dump();

