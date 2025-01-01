import { CompanySearch } from './company';

interface SearchResponse {
  data: CompanySearch[];
}

export const searchCompanies = async (query: string) => {
  try {
    const apiKey = import.meta.env.VITE_API_KEY;
    if (!apiKey) {
      throw new Error('API key is missing.');
    }

    const response = await fetch(
      `https://financialmodelingprep.com/api/v3/search?query=${query}&limit=10&exchange=NASDAQ&apikey=${apiKey}`
    );

    if (!response.ok) {
      throw new Error(`HTTP error! Status: ${response.status}`);
    }

    const data: SearchResponse = await response.json();
    return data;
  } catch (error) {
    if (error instanceof Error) {
      console.error('Error message:', error.message);
      return error.message;
    }
    console.error('Unknown error:', error);
    return 'An unknown error occurred.';
  }
};
