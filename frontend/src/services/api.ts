import axios from "axios";

const api = axios.create({
  // Podajemy bezpośredni adres do Twojego API w Azure
  baseURL: "https://cloud-task-manager-api-v2-94570.azurewebsites.net/api",
});

export default api;