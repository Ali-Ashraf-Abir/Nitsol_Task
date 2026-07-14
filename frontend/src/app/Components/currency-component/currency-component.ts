import { Component, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormBuilder,
  ReactiveFormsModule,
  Validators
} from '@angular/forms';
import { Router } from '@angular/router';

import { CurrencyService } from '../../core/services/currency.service';
import { AuthService } from '../../core/services/auth.service';

@Component({
  selector: 'app-currency',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  templateUrl: './currency-component.html',
  styleUrl: './currency-component.css'
})
export class CurrencyComponent {

  private fb = inject(FormBuilder);
  private currencyService = inject(CurrencyService);
  private auth = inject(AuthService);
  private router = inject(Router);

  loading = signal(false);
  result = signal<number | null>(null);

  currencies = [
    'USD',
    'EUR',
    'GBP',
    'JPY',
    'AUD',
    'CAD',
    'CHF',
    'CNY',
    'INR',
    'BDT',
    'SGD',
    'NZD',
    'SEK',
    'NOK',
    'DKK',
    'AED',
    'SAR',
    'QAR',
    'MYR',
    'THB'
  ];

  form = this.fb.nonNullable.group({
    fromCurrency: ['USD', Validators.required],
    toCurrency: ['BDT', Validators.required],
    amount: [1, [Validators.required, Validators.min(0.01)]]
  });

  convert() {

    if (this.form.invalid) return;

    this.loading.set(true);

    const value = this.form.getRawValue();

    this.currencyService.convert(
      value.fromCurrency,
      value.toCurrency,
      value.amount
    ).subscribe({

      next: (res) => {
        this.result.set(res.convertedAmount);
        this.loading.set(false);
      },

      error: () => {
        this.loading.set(false);
      }

    });

  }

  swapCurrencies() {

    const from = this.form.value.fromCurrency;
    const to = this.form.value.toCurrency;

    this.form.patchValue({
      fromCurrency: to!,
      toCurrency: from!
    });

  }

  logout() {

    this.auth.logout();
    this.router.navigate(['/login']);

  }

}