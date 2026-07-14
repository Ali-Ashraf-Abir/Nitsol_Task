import { Injectable, inject } from '@angular/core';
import { ApiService } from './api.service';

import { Observable } from 'rxjs';
import { CurrencyResponse } from '../models/currency.dto';

@Injectable({
  providedIn: 'root'
})
export class CurrencyService {

  private api = inject(ApiService);

  convert(
    from: string,
    to: string,
    amount: number
  ): Observable<CurrencyResponse> {

    return this.api.get<CurrencyResponse>(
      `currency/convert?fromCurrency=${from}&toCurrency=${to}&amount=${amount}`
    );
  }

}