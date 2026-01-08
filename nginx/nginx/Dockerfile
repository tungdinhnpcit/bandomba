FROM nginx:latest

COPY nginx/nginx.conf /etc/nginx/nginx.conf
COPY nginx/publickey.pem /etc/ssl/publickey.pem
COPY nginx/private.key /etc/ssl/private.key

#RUN apt-get update && apt-get install vim -y && apt-get install nmap -y