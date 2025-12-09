# ============================
#       BUILD STAGE
# ============================
FROM node:24-alpine AS build

WORKDIR /app

COPY package.json package-lock.json* ./
RUN npm install

COPY . ./
RUN npm run build --prod

# ============================
#       RUNTIME STAGE
# ============================
FROM nginx:alpine AS final

WORKDIR /usr/share/nginx/html

RUN rm -rf ./*

COPY --from=build /app/dist/adres.web/browser ./

EXPOSE 80

CMD ["nginx", "-g", "daemon off;"]
