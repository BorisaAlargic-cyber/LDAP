using System;
using System.Collections.Generic;
using IIS.Model;
using IIS.Repository;

namespace IIS.Service
{
    public class FlightService
    {
        public Flight CreateFlight(Flight flight)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    Flight dbFlight = unitOfWork.Flights.Get(flight.Id);

                    if(dbFlight != null)
                    {
                        return null;
                    }

                    dbFlight = new Flight();

                    dbFlight.FlightNumber = flight.FlightNumber;
                    dbFlight.DateOfDeparture = flight.DateOfDeparture;
                    dbFlight.DateOfArrival = flight.DateOfArrival;
                    dbFlight.MilesToGet = flight.MilesToGet;
                    dbFlight.MilesToDiscount = flight.MilesToDiscount;
                    dbFlight.MilesDiscountPercent = flight.MilesDiscountPercent;

                    unitOfWork.Flights.Add(dbFlight);
                    unitOfWork.Complete();

                    return dbFlight;
                }
            }catch(Exception e)
            {
                return null;
            }
        }

        public Flight EditFlight(Flight flight)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    Flight dbFlight = unitOfWork.Flights.Get(flight.Id);

                    dbFlight.FlightNumber = flight.FlightNumber;
                    dbFlight.DateOfDeparture = flight.DateOfDeparture;
                    dbFlight.DateOfArrival = flight.DateOfArrival;
                    dbFlight.MilesToGet = flight.MilesToGet;
                    dbFlight.MilesToDiscount = flight.MilesToDiscount;
                    dbFlight.MilesDiscountPercent = flight.MilesDiscountPercent;

                    unitOfWork.Flights.Update(dbFlight);
                    unitOfWork.Complete();

                    return dbFlight;
                }
            }catch(Exception e)
            {
                return null;
            }
        }

        public Flight GetFlight(int flightId)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    Flight dbFlight = unitOfWork.Flights.Get(flightId);

                    if(dbFlight == null)
                    {
                        return null;
                    }

                    return dbFlight;
                }
            }catch(Exception e)
            {
                return null;
            }
        }

        public IEnumerable<Flight> GetAllFlights()
        {
            try
            {
                using(UnitOfWork unitOfWork =  new UnitOfWork(new IISContext()))
                {
                    IEnumerable<Flight> dbFlight = unitOfWork.Flights.GetAll();

                    if(dbFlight == null)
                    {
                        return null;
                    }

                    return dbFlight;
                }
            }
            catch (Exception ee)
            {
                return null;
            }
        }

        public FlightAdditionals CreateFlightAdditionals(FlightAdditionals flightAdditionals)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    FlightAdditionals dbFlightAdditionals = unitOfWork.FlightAdditionals.Get(flightAdditionals.Id);

                    if(dbFlightAdditionals != null)
                    {
                        return null;
                    }

                    dbFlightAdditionals = new FlightAdditionals();

                    dbFlightAdditionals.Name = flightAdditionals.Name;
                    dbFlightAdditionals.Price = flightAdditionals.Price;
                    dbFlightAdditionals.MilesToGet = flightAdditionals.MilesToGet;
                    dbFlightAdditionals.MilesToDiscount = flightAdditionals.MilesToDiscount;
                    dbFlightAdditionals.MilesDiscountPercent = flightAdditionals.MilesDiscountPercent;

                    unitOfWork.FlightAdditionals.Add(dbFlightAdditionals);
                    unitOfWork.Complete();

                    return dbFlightAdditionals;
                }
            }catch(Exception ee)
            {
                return null;
            }
        }

        public FlightAdditionals EditFlightAdditionals(FlightAdditionals flightAdditionals)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    FlightAdditionals dbFlightAdditionals = unitOfWork.FlightAdditionals.Get(flightAdditionals.Id);

                    dbFlightAdditionals.Name = flightAdditionals.Name;
                    dbFlightAdditionals.Price = flightAdditionals.Price;
                    dbFlightAdditionals.MilesToGet = flightAdditionals.MilesToGet;
                    dbFlightAdditionals.MilesToDiscount = flightAdditionals.MilesToDiscount;
                    dbFlightAdditionals.MilesDiscountPercent = flightAdditionals.MilesDiscountPercent;

                    unitOfWork.FlightAdditionals.Update(dbFlightAdditionals);
                    unitOfWork.Complete();

                    return dbFlightAdditionals;
                }
            }
            catch (Exception ee)
            {
                return null;
            }
        }

        public IEnumerable<FlightAdditionals> GetAllFlightAdditionals()
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    IEnumerable<FlightAdditionals> dbFlightAdditionals = unitOfWork.FlightAdditionals.GetAll();

                    if(dbFlightAdditionals == null)
                    {
                        return null;
                    }

                    return dbFlightAdditionals;
                }
            }catch(Exception ee)
            {
                return null;
            }
        }

        public Airport CreateAirport(Airport airport)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    Airport dbAirport = unitOfWork.Airports.Get(airport.Id);

                    if(dbAirport != null)
                    {
                        return null;
                    }

                    dbAirport = new Airport();

                    dbAirport.Name = airport.Name;
                    dbAirport.Code = airport.Code;
                    

                    unitOfWork.Airports.Add(dbAirport);
                    unitOfWork.Complete();

                    unitOfWork.Airports.Update(dbAirport);
                    dbAirport.destination = airport.destination;
                    
                    unitOfWork.Complete();

                    return dbAirport;
                }
            }catch(Exception ee)
            {
                return null;
            }
        }

        public Airport EditAirport(Airport airport)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    Airport dbAirport = unitOfWork.Airports.Get(airport.Id);


                    dbAirport.Name = airport.Name;
                    dbAirport.Code = airport.Code;
                    dbAirport.destination = airport.destination;

                    unitOfWork.Airports.Update(dbAirport);
                    unitOfWork.Complete();                    

                    return dbAirport;
                }
            }
            catch (Exception ee)
            {
                return null;
            }
        }

        public IEnumerable<Airport> GetAllAirports()
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    IEnumerable<Airport> dbAirports = unitOfWork.Airports.GetAll();

                    if(dbAirports == null)
                    {
                        return null;
                    }

                    return dbAirports;
                }
            }catch(Exception ee)
            {
                return null;
            }

            
        }

        public Airplane CreateAirplane(Airplane airplane)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    Airplane dbAirplane = unitOfWork.Airplanes.Get(airplane.Id);

                    if(dbAirplane != null)
                    {
                        return null;
                    }

                    dbAirplane = new Airplane();

                    dbAirplane.Type = airplane.Type;
                    dbAirplane.Model = airplane.Model;
                    dbAirplane.NumberOfPassengers = airplane.NumberOfPassengers;

                    unitOfWork.Airplanes.Add(dbAirplane);
                    unitOfWork.Complete();

                    return dbAirplane;
                }
            }catch(Exception ee)
            {
                return null;
            }
        }

        public Airplane EditAirplane(Airplane airplane)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    Airplane dbAirplane = unitOfWork.Airplanes.Get(airplane.Id);

                    dbAirplane.Type = airplane.Type;
                    dbAirplane.Model = airplane.Model;
                    dbAirplane.NumberOfPassengers = airplane.NumberOfPassengers;

                    unitOfWork.Airplanes.Update(dbAirplane);
                    unitOfWork.Complete();

                    return dbAirplane;
                }
            }
            catch (Exception ee)
            {
                return null;
            }
        }

        public IEnumerable<Airplane> GetAllAirplanes()
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    IEnumerable<Airplane> dbAirplane = unitOfWork.Airplanes.GetAll();

                    if(dbAirplane == null)
                    {
                        return null;
                    }

                    return dbAirplane;
                }
            }catch(Exception ee)
            {
                return null;
            }

        }

        public void DeleteAirplane(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    Airplane airplane = unitOfWork.Airplanes.Get(id);

                    unitOfWork.Airplanes.Update(airplane);
                    airplane.Deleted = true;

                    unitOfWork.Complete();
                }
            }
            catch (Exception ee)
            {

            }
        }

        public void DeleteFlight(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    Flight flight = unitOfWork.Flights.Get(id);

                    unitOfWork.Flights.Update(flight);
                    flight.Deleted = true;

                    unitOfWork.Complete();
                }
            }
            catch (Exception ee)
            {

            }
        }

        public void DeleteAirport(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    Airport airport = unitOfWork.Airports.Get(id);

                    unitOfWork.Airports.Update(airport);
                    airport.Deleted = true;

                    unitOfWork.Complete();
                }
            }
            catch (Exception ee)
            {

            }
        }

    }
}
