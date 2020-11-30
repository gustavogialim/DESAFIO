export interface DebtInstallment {
  Id: number;
  DueDate: Date;
  FinalValue: number;
}

export interface Debt {
  Id: number;
  DueDate: Date;
  InstallmentsCount: number;
  LateDays: number;
  OriginalValue: number;
  InterestValue: number;
  FinalValue: number;
  OrientationPhone: string;
  Installments: DebtInstallment[];
}
