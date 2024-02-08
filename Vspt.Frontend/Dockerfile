FROM node:12.7-alpine AS build
LABEL name="romanye/vspt-frontend"
WORKDIR /usr/src/app
RUN npm run build
COPY ["Vspt.Frontend/package.json", "package.json"]
COPY ["Vspt.Frontend/package-lock.json", "package-lock.json"]
COPY . .

#STAGE 2
FROM nginx:1.17.1-alpine
COPY ["Vspt.Frontend/nginx.conf", "/etc/nginx/nginx.conf"]
COPY ["Vspt.Frontend/dist/vspt-frontend", "/usr/share/nginx/html"]

