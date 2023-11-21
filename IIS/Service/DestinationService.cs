using System;
using System.Collections.Generic;
using IIS.Model;
using IIS.Model.Request;
using IIS.Repository;

namespace IIS.Service
{
    public class DestinationService
    {
        public Destination CreateDestination(Destination destination)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    Destination dbDestination = unitOfWork.Destinations.Get(destination.Id);

                    if(dbDestination != null)
                    {
                        return null;
                    }

                    dbDestination = new Destination();

                    dbDestination.Name = destination.Name;
                    dbDestination.Code = destination.Code;

                    unitOfWork.Destinations.Add(dbDestination);
                    unitOfWork.Complete();

                    return dbDestination;
                }
            }catch(Exception e)
            {
                return null;
            }
        }

        public Destination EditDestination(Destination destination)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    Destination dbDestination = unitOfWork.Destinations.Get(destination.Id);

                    if(dbDestination == null)
                    {
                        return null;
                    }

                    dbDestination.Name = destination.Name;
                    dbDestination.Code = destination.Code;

                    unitOfWork.Destinations.Update(dbDestination);
                    unitOfWork.Complete();

                    return dbDestination;
                }
            }catch(Exception e)
            {
                return null;
            }
        }

        public Destination GetDestination(int destinationId)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    Destination dbDestination = unitOfWork.Destinations.Get(destinationId);

                    if(dbDestination == null)
                    {
                        return null;
                    }

                    return dbDestination;

                }
            }catch(Exception e)
            {
                return null;
            }
        }
        public IEnumerable<Destination> GetAllDestinations()
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    IEnumerable<Destination> dbDestinations = unitOfWork.Destinations.GetAll();

                    if(dbDestinations == null)
                    {
                        return null;
                    }

                    return dbDestinations;
                }
            }catch(Exception ee)
            {
                return null;
            }
        }


        public Country CreateCountry(Country country)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    Country dbCountry = unitOfWork.Countries.Get(country.Id);

                    if(dbCountry != null)
                    {
                        return null;
                    }

                    dbCountry = new Country();
                    dbCountry.Name = country.Name;
                    dbCountry.ZipCode = country.ZipCode;

                    unitOfWork.Countries.Add(dbCountry);
                    unitOfWork.Complete();

                    return dbCountry;
                }
            }catch(Exception e)
            {
                return null;
            }
        }

        public Country EditCountry(Country country)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    Country dbCountry = unitOfWork.Countries.Get(country.Id);

                    if(dbCountry == null)
                    {
                        return null;
                    }

                    dbCountry.Name = country.Name;
                    dbCountry.ZipCode = country.ZipCode;

                    unitOfWork.Countries.Update(dbCountry);
                    unitOfWork.Complete();

                    return dbCountry;
                }
            }catch(Exception e)
            {
                return null;
            }
        }

        public Country GetCountry(int countryId)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    Country dbCountry = unitOfWork.Countries.Get(countryId);

                    if(dbCountry == null)
                    {
                        return null;
                    }

                    return dbCountry;
                }
            }catch(Exception e)
            {
                return null;
            }
        }

        public IEnumerable<Country> GetAllCountries()
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    IEnumerable<Country> dbCountries = unitOfWork.Countries.GetAll();

                    if(dbCountries == null)
                    {
                        return null;
                    }

                    return dbCountries;
                 }
            }catch(Exception ee)
            {
                return null;
            }
        }



        public City CreateCity(City city)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    City dbCity = unitOfWork.Cities.Get(city.Id);

                    if(dbCity != null)
                    {
                        return null;
                    }

                    dbCity = new City();

                    dbCity.Name = city.Name;

                    unitOfWork.Cities.Add(dbCity);
                    unitOfWork.Complete();

                    return dbCity;
                }
            }catch(Exception e)
            {
                return null;
            }
        }

        public City EditCity(City city)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    City dbCity = unitOfWork.Cities.Get(city.Id);

                    if(dbCity == null)
                    {
                        return null;
                    }

                    dbCity.Name = city.Name;

                    unitOfWork.Cities.Update(dbCity);
                    unitOfWork.Complete();

                    return dbCity;
                }
            }catch(Exception e)
            {
                return null;
            }
        }

        public City GetCity(int cityId)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    City dbCity = unitOfWork.Cities.Get(cityId);

                    if(dbCity == null)
                    {
                        return null;
                    }

                    return dbCity;
                }
            }catch(Exception e)
            {
                return null;
            }
        }

        public IEnumerable<City> GetAllCities()
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    IEnumerable<City> dbCities = unitOfWork.Cities.GetAll();

                    if(dbCities == null)
                    {
                        return null;
                    }

                    return dbCities;
                }
            }catch(Exception ee)
            {
                return null;
            }

        }

        public PurchesersAdditionals CreatePurcherseAdd(PurchersAdditionalsRequest purchesersAdditionalsRequest)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    PurchesersAdditionals dbAdditionals = new PurchesersAdditionals();

                    unitOfWork.PurchesersAdditionals.Add(dbAdditionals);
                    unitOfWork.Complete();

                    unitOfWork.PurchesersAdditionals.Update(dbAdditionals);
                    
                    dbAdditionals.Purcheser = unitOfWork.Purchesers.Get(purchesersAdditionalsRequest.PurchersId);
                    dbAdditionals.FlightAdditionals = unitOfWork.FlightAdditionals.Get(purchesersAdditionalsRequest.FlightAdditoinalsId);

                    unitOfWork.Complete();


                    return dbAdditionals;
                }
            }catch(Exception ee)
            {
                return null;
            }
        }

        public void DeleteDestination(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    Destination destination = unitOfWork.Destinations.Get(id);

                    unitOfWork.Destinations.Update(destination);
                    destination.Deleted = true;

                    unitOfWork.Complete();
                }
            }
            catch (Exception ee)
            {
                
            }
        }

        public void DeleteCountry(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    Country country = unitOfWork.Countries.Get(id);

                    unitOfWork.Countries.Update(country);
                    country.Deleted = true;

                    unitOfWork.Complete();
                }
            }
            catch (Exception ee)
            {

            }
        }

        public void DeleteCity(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    City city = unitOfWork.Cities.Get(id);

                    unitOfWork.Cities.Update(city);
                    city.Deleted = true;

                    unitOfWork.Complete();
                }
            }
            catch (Exception ee)
            {

            }
        }

        public void DeleteAdditionals(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork(new IISContext()))
                {
                    FlightAdditionals flightAdditionals = unitOfWork.FlightAdditionals.Get(id);

                    unitOfWork.FlightAdditionals.Update(flightAdditionals);
                    flightAdditionals.Deleted = true;

                    unitOfWork.Complete();
                }
            }
            catch (Exception ee)
            {

            }
        }
    }
}