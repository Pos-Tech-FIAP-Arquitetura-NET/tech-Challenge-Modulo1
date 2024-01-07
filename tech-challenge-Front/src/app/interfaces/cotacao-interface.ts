export interface DolarInterface {
    USDBRL: {
      code: string;
      codein: string;
      name: string;
      high: string;
      low: string;
      varBid: string;
      pctChange: string;
      bid: string;
      ask: string;
      timestamp: string;
      create_date: string;
    };
  }

  export interface EuroInterface {
    EURBRL: {
      code: string;
      codein: string;
      name: string;
      high: string;
      low: string;
      varBid: string;
      pctChange: string;
      bid: string;
      ask: string;
      timestamp: string;
      create_date: string;
    };
  }

  export interface PeriodoRelatorioCotacaoMoeda {
    [x: string]: any;
    code?: string;
    codein: string;
    name?: string;
    high: string;
    low: string;
    varBid: string;
    pctChange: string;
    bid: string;
    ask: string;
    timestamp: string;
    create_date?: string;
  }
