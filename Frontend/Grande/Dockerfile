# Use an official Node.js image as the base image
FROM node:14.17.3-alpine

# Set the working directory within the container
WORKDIR /app

# Copy the package.json and package-lock.json files to the container
COPY package.json .
COPY package-lock.json .

# Install dependencies
RUN npm install

# Copy the rest of your application files
COPY . .

# Build your React application
RUN npm run build

# Expose the port that the server will run on
EXPOSE 5000

# Set the command to serve the built application
CMD ["npm", "run", "dev"]