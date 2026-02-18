const sql = require('mssql');

const config = {
    user: process.env.DB_USER || 'sa',
    password: process.env.DB_PASSWORD || 'TuPasswordFuerte2026!',
    server: process.env.DB_SERVER || '143.110.239.84', 
    database: process.env.DB_DATABASE || 'TSS',
    options: {
        encrypt: false, // Importante para conexiones remotas
        trustServerCertificate: true 
    }
};

let pool = null;

async function connectDB() {
  try {
    if (!pool) {
      pool = await sql.connect(config);
      console.log('Conectado a SQL Server');
    }
    return pool;
  } catch (error) {
    console.error('Error conectando a SQL Server:', error);
    throw error;
  }
}

// Helper que soporta consultas con placeholders tipo $1, $2... y los convierte a @p1,@p2
async function query(text, params = []) {
  await connectDB();
  const request = pool.request();
  params.forEach((p, i) => {
    const name = `p${i + 1}`;
    request.input(name, p);
  });
  const sqlText = text.replace(/\$(\d+)/g, (m, n) => `@p${n}`);
  const result = await request.query(sqlText);
  return result;
}

module.exports = { connectDB, query, sql };
