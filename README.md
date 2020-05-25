# Tutorial: Build dot Net Core Web API protected by Azure AD
A simple Azure AD secured, dot net core Web API with Docker support.

## Getting Started

Follow [this](https://www.youtube.com/watch?v=srJZCCvst8o&t=78s) turorial to setup Azure artefacts and collect below parameters to update `appsettings.json` 
   - Instance 
   - Domain
   - TenantId
   - ClientId

If you don't want to download and buid code, you can use [Docker Hub Image](https://hub.docker.com/repository/docker/digitaltechconsulting/secure-web-api) and pass `Instance` , `Domain`, `TenantId` and `ClientId` parameters while creating the contianer.


> Before setting up docker container on your machine you will need to register client in your Azure Active Directory and collect `Instance` , `Domain`, `TenantId`, `ClientId` parameters

You can also use `docker-compose` command to construct the container.  After updating [this](https://github.com/digitaltechconsulting/dot-net-core-secure-webapi-azure-ad-docker-support/blob/master/docker-compose.yml) file with the required variables i.e. `Instance`,`Domain`, `TenantId` and `ClientId` run below command

PUll the image
`
docker pull digitaltechconsulting/secure-web-api:1.0
`
## Setting up container on your machine

Once you have downloaded `digitaltechconsulting/secure-web-api:latest` on your machine.  You can setup container using `docker-compose` OR  `docker run` command

### `docker-compose` approach
- Make sure you are in the same directory where your [`docker-compose.yml`](https://github.com/digitaltechconsulting/dot-net-core-secure-webapi-azure-ad-docker-support/blob/master/docker-compose.yml) file is
- Replace `INSTANCE` , `DOMAIN` , `TENANTID` and `CLIENTID` values
- Run below command

`
docker-compose up -d --no-build
`

### `docker run`  approach

Run below command after pulling latest image

`
docker run --name secure-web-api -d -p 8080:80 -e "READ_AZUREAD_FROM_ENVIRONMENT=true" -e "INSTANCE=https://login.microsoftonline.com/" -e "DOMAIN=--YOUR DOMAIN--" -e "TENANTID=--YOUR TENANTID--" -e "CLIENTID=--YOUR CLIENTID--" -e "ASPNETCORE_URLS=https://+:443;http://+:80" digitaltechconsulting/secure-web-api:1.0
`

> To verify if container is up and running you can hit URL `http://localhost:8080/api/test` If everything is fine, it should echo back **Hello World-**

