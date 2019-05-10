# Happy Path API - Thin controllers and separated concerns

This repo contains an infinitely small API which demonstrates the usage of mediatr and exception handling middleware in a .net core API

The [controller](HappyPathApi/Controllers/PersonerController.cs) is kept as thin as possible, and uses [Mediatr](https://github.com/jbogard/MediatR) as a layer of abstraction between MVC and the business layer. No error handling is done in the controller itself. It is oblivious to anything but the happy path, so any errors thrown in the business layer bubble up to the [error handling middleware](HappyPathApi/Middleware/ErrorHandler.cs).
