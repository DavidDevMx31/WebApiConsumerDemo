# WebApiConsumerDemo
Example code for consuming an API from a WPF app.

## Introduction
This project is a simple example of how to call an API using C#. 

The first windows fetches web comics from [xkcd](https://xkcd.com) and shows them on the screen.

The second window fetches sunrise and sunset times. 
This information is provided by the [Sunrise Sunset API](https://sunrise-sunset.org/api).

## Technologies
- Windows Presentation Foundation (WPF)
- C#

## Requirements
The destination platform is .Net framework 4.6.1

## To-do
- Add controls in the SunInfo windows to specify the latitude and longitude for the request (both are currently fixed).

## Inspiration
This solution was inspired by this [Tim Corey's tutorial](https://www.youtube.com/watch?v=aWePkE2ReGw). 
However, I extended the tutorial's example by adding a cache to prevent unnecesary calls to the web comics API.
