import axios from "axios";

const api = axios.create({
  // Dodajemy "/api" do adresu pobranego ze zmiennej środowiskowej
  baseURL: import.meta.env.VITE_API_URL + "/api",
});

export default api;