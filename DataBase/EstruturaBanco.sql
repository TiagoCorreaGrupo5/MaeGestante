CREATE DATABASE MaeGestante;

-- Tabela "StatusConsulta" para armazenar os tipos de status da consulta
CREATE TABLE StatusConsulta (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    Nome NVARCHAR(50) -- Por exemplo, 'Agendada', 'Realizada', 'Cancelada', etc.
);

-- Inserção de tipos de status de consulta
INSERT INTO StatusConsulta (Nome)
VALUES ('Agendada'), ('Realizada'), ('Cancelada');

-- Tabela "TiposUsuario" para armazenar os tipos de usuário
CREATE TABLE TiposUsuario (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    Nome NVARCHAR(50) -- Por exemplo, 'Gestante' ou 'Profissional'
);

-- Inserção de tipos de usuário
INSERT INTO TiposUsuario (Nome)
VALUES ('Gestante'), ('Profissional');

-- Tabela "Especialidades" para armazenar informações sobre as especialidades dos profissionais
CREATE TABLE Especialidades (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    Nome NVARCHAR(100)
);

-- Inserção de tipos de especialidades
INSERT INTO Especialidades (Nome)
VALUES ('Obstetrícia'), ('Ginecologia');

-- Tabela "Usuarios" para armazenar informações sobre os usuários do aplicativo
CREATE TABLE Usuarios (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    Nome NVARCHAR(255),
    Sobrenome NVARCHAR(255),
    Email NVARCHAR(255),
    Senha NVARCHAR(255),
    TipoUsuarioID INT,
    FOREIGN KEY (TipoUsuarioID) REFERENCES TiposUsuario(ID)
);

-- Tabela "ProfissionaisSaude" para armazenar informações sobre os profissionais de saúde
CREATE TABLE ProfissionaisSaude (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    Nome NVARCHAR(255),
    Contato NVARCHAR(255),
    UsuarioID INT UNIQUE,
    EspecialidadeID INT,
    FOREIGN KEY (UsuarioID) REFERENCES Usuarios(ID),
    FOREIGN KEY (EspecialidadeID) REFERENCES Especialidades(ID)
);

-- Tabela "Gestantes" para armazenar informações específicas das gestantes
CREATE TABLE Gestantes (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    Nome NVARCHAR(255),
    DataPrevistaParto DATE,
    UsuarioID INT UNIQUE,
    FOREIGN KEY (UsuarioID) REFERENCES Usuarios(ID)
);

-- Tabela "HistoricoMedico" para armazenar o histórico médico das gestantes
CREATE TABLE HistoricoMedico (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    GestanteID INT,
    ProfissionalID INT,
    DataRegistro DATETIME,
    Descricao TEXT,
    FOREIGN KEY (GestanteID) REFERENCES Gestantes(ID),
    FOREIGN KEY (ProfissionalID) REFERENCES ProfissionaisSaude(ID)
);

-- Tabela "Consultas" para registrar as consultas agendadas
CREATE TABLE Consultas (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    GestanteID INT,
    ProfissionalID INT,
    DataHoraConsulta DATETIME,
    StatusConsultaID INT,
    FOREIGN KEY (GestanteID) REFERENCES Gestantes(ID),
    FOREIGN KEY (ProfissionalID) REFERENCES ProfissionaisSaude(ID),
    FOREIGN KEY (StatusConsultaID) REFERENCES StatusConsulta(ID)
);

-- Tabela "Receitas" para armazenar informações sobre as receitas médicas
CREATE TABLE Receitas (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    GestanteID INT,
    ProfissionalID INT,
    Medicamentos TEXT,
    DataPrescricao DATE,
    FOREIGN KEY (GestanteID) REFERENCES Gestantes(ID),
    FOREIGN KEY (ProfissionalID) REFERENCES ProfissionaisSaude(ID)
);

-- Tabela "Exames" para armazenar informações sobre os exames médicos
CREATE TABLE Exames (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    GestanteID INT,
    ProfissionalID INT,
    TipoExame NVARCHAR(100),
    DataSolicitacao DATE,
    Resultado TEXT, -- Campo para armazenar o resultado do exame (pode ser um caminho de arquivo)
    FOREIGN KEY (GestanteID) REFERENCES Gestantes(ID),
    FOREIGN KEY (ProfissionalID) REFERENCES ProfissionaisSaude(ID)
);

-- Tabela "CartoesGestante" para permitir que gestantes façam upload de seus cartões de gestante
CREATE TABLE CartoesGestante (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    GestanteID INT,
    DataEnvio DATETIME,
    CaminhoArquivo NVARCHAR(255), -- Caminho do arquivo de imagem do cartão
    FOREIGN KEY (GestanteID) REFERENCES Gestantes(ID)
);

-- Tabela "AgendaEspecialista" para armazenar os horários de disponibilidade dos profissionais
CREATE TABLE AgendaEspecialista (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    ProfissionalID INT,
    DiaSemana INT, -- 1 representa domingo, 2 segunda-feira, ..., 7 sábado
    HoraInicioManha TIME, -- Horário de início da manhã
    HoraFimManha TIME, -- Horário de fim da manhã
    HoraInicioTarde TIME, -- Horário de início da tarde
    HoraFimTarde TIME, -- Horário de fim da tarde
    FOREIGN KEY (ProfissionalID) REFERENCES ProfissionaisSaude(ID)
);

-- Tabela "DiasFolga" para armazenar os dias de folga dos profissionais de saúde
CREATE TABLE DiasFolga (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    ProfissionalID INT,
    DataFolga DATE, -- Data do dia de folga
    Motivo NVARCHAR(255), -- Motivo da folga (opcional)
    FOREIGN KEY (ProfissionalID) REFERENCES ProfissionaisSaude(ID)
);
