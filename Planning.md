# Picnic Platform Technical Planning

##Introduction

This document is created to show the technical details of the Picnic Platform
that is going to be developed. A general architecture is given to the readers
for them to visualize what will be developed and provides a roadmap for
achieving the required product. This document also contains HR requirements and
budgeting.

## Requirements

The Picnic Platform would have the below requirements. These requirements can be
split up as MVP, Phase 2, and Phase 3 for creating an agile delivery cycle.

### MVP

- All individuals should create a profile and login into the system with their
  credentials
- Members should be able to organize picnics at specific locations
- Members should be able to invite friends and family to the meetings they have
  created
- Picnics should have a collaborative list for the members to list what they
  will bring to the picnic

### Phase 2

- Members should be able to comment and tag each other on meetings
- Members may choose to pay a subscription fee for private picnics
- Members should be able to receive notification about their picnic activities

### Phase 3

- Panel users need to be able to access some reports or audit logs via the panel

## Overall Architecture

For being able to achieve the above requirements, there is an overall architecture
diagram provided below. This is a microservice application architecture
that uses the Event Sourcing pattern to coordinate data consistency between
services.

![Overall architecture of Picnic Platform](OverallArchitecture.png)

The parts with green backgrounds should be developed/configured in the MVP phase of
the product.

## Technologies Used

### Cloud Environment

- Amazon Web Services as the cloud provider
- Amazon Elastic Container Service for running microservices as containers
- Amazon Cognito for Identity Management and Authentication
- Amazon RDS for PostgreSQL
- Amazon Managed Streaming for Apache Kafka (MSK) for Event Store
- Amazon MemoryDB for Redis
- MongoDB Atlas for MongoDB
- Amazon Redshift for DWH reporting

### Microservices

- .NET6

### Mobile Applications

- Native IOS
- Native Android

### Admin Panel

- React

### Reporting

- Apache Nifi for ETL flow

## Roadmap

You can find a technical roadmap with estimated time costs on below.

![Technical Roadmap](TechnicalRoadmap.png)

## Team Composition

For the MVP phase of the project there needs to be at least 1 Senior and 1 Junior
.NET developers involved in the design, configuration, and development processes
of the app. Because the front end will be delivered as a mobile application at
least 1 IOS and 1 Android developer should be included.

In Phase 2, Admin panel development starts, so there should be a Front-end
developer included in this phase.

Because we released the product to the production environment and the support of a
DevOps Engineer should be included for helping developers to focus on new
feature developments majorly.

## Budget

You can find an overall estimated budget below for the 3 phases mentioned
above. Nearly 250k$ will be needed to make this scope of the product up and
running for 9 months.

![Budget](Budget.png)

[You can access the budget document here!](https://docs.google.com/spreadsheets/d/1b-Ipr0qxdi3UDTNpE2rj1c-iUPQClobMsx6gkSr3F7o/edit?usp=sharing)
