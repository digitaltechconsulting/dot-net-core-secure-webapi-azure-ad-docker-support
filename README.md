# Tutorial: Build dot Net Core Web API protected by Azure AD
A simple Azure AD secured, dot net core Web API with Docker support

## Getting Started

Follow [this](https://www.youtube.com/watch?v=srJZCCvst8o&t=78s) turorial to setup Azure artefacts and collect below parameters to update `appsettings.json` 
   - Instance 
   - Domain
   - TenantId
   - ClientId

Alternatively, you can use [Docker Hub Image](https://hub.docker.com/repository/docker/digitaltechconsulting/secure-web-api) and pass `Instance` , `Domain`, `TenantId` and `ClientId` parameters while creating the contianer.

You can also use `docker-compose` command to construct the container.  After updating [this](https://github.com/digitaltechconsulting/dot-net-core-secure-webapi-azure-ad-docker-support/blob/master/docker-compose.yml) file with the required variables i.e. `Instance`,`Domain`, `TenantId` and `ClientId` run below command

PUll the image
`
docker pull digitaltechconsulting/secure-web-api:latest
`
## Setting up container on your machine

Once you have downloaded `digitaltechconsulting/secure-web-api:latest` on your machine.  You can setup container using `docker-compose` OR  `docker run` command

### `docker-compose` approach
- Make sure you are in the same directory where your [`docker-compose.yml`](https://github.com/digitaltechconsulting/dot-net-core-secure-webapi-azure-ad-docker-support/blob/master/docker-compose.yml) file is
- 
- Run below command

`
docker-compose up -d --no-build
`

### `docker run`  approach

