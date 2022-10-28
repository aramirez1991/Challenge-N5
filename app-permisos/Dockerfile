FROM node:latest AS build
WORKDIR /app
COPY package.json ./

RUN npm install
COPY . .
RUN npm run build

FROM nginx:1.19.0-alpine AS prod-stage
COPY --from=build /app/build /usr/share/nginx/html
RUN apk update && apk upgrade
COPY nginx/nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 3000
CMD ["nginx", "-g" , "daemon off;"]