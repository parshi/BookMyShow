Here is the postman collection link
https://www.getpostman.com/collections/3634af0fe91e09cf87d6

here few apis signature provied for handling movie ticketing system

1.Add movie
http://localhost:49704/api/movie/addmovie
{
  "Name": "Avengers"
}


2.Add screen 
http://localhost:49704/api/screens/addscreen
{
  "Name": "Asia Multiplex",
  "Location": "SilkBoard",
  "City":"Banglore",
  "Capacity":250,
  "SliverClass":"100",
  "GoldClass":"100",
  "Platinum":"50",
  "VIP":"0"
}

3.Add Movie to Cinema
http://localhost:49704/api/screening/addmovietocinema
{
  "Movie": "Avengers",
  "Cinema":"Mega Multiplex",
  "ShowTime":"06:00 PM",
  "ShowDate":"20-08-2020"
} 
