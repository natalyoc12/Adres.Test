import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideHttpClient } from '@angular/common/http';
import { PROCUREMENT_PROVIDERS } from '../../data/data.module';

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideHttpClient(),
    ...PROCUREMENT_PROVIDERS,
  ],
};

export default {
  plugins: {
    '@tailwindcss/postcss': {},
  },
};
