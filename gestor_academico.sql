
-- Crear base de datos para el Gestor Académico
CREATE DATABASE IF NOT EXISTS Gestor_Academico;
USE Gestor_Academico;

-- Tabla Usuarios
CREATE TABLE IF NOT EXISTS Usuarios (
    id_usuario INT AUTO_INCREMENT PRIMARY KEY,
    usuario_login VARCHAR(50) NOT NULL UNIQUE,
    contraseña VARCHAR(255) NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    rol VARCHAR(50) NOT NULL
);

-- Insertar datos de ejemplo en Usuarios
INSERT INTO Usuarios (usuario_login, contraseña, nombre, rol) VALUES
('admin', 'admin123', 'Administrador General', 'Administrador'),
('jdoe', '12345', 'John Doe', 'Docente');

-- Tabla Estudiantes
CREATE TABLE IF NOT EXISTS Estudiantes (
    id_estudiante INT AUTO_INCREMENT PRIMARY KEY,
    cedula VARCHAR(20) NOT NULL UNIQUE,
    nombre VARCHAR(100) NOT NULL,
    correo VARCHAR(100),
    fecha_nacimiento DATE
);

-- Insertar datos de ejemplo en Estudiantes
INSERT INTO Estudiantes (cedula, nombre, correo, fecha_nacimiento) VALUES
('0102030405', 'Ana Torres', 'ana.torres@email.com', '2002-05-10'),
('0607080910', 'Luis Pérez', 'luis.perez@email.com', '2001-11-22');

-- Tabla Evaluaciones
CREATE TABLE IF NOT EXISTS Evaluaciones (
    id_evaluacion INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL
);

-- Insertar datos de ejemplo en Evaluaciones
INSERT INTO Evaluaciones (nombre) VALUES
('Parcial 1'),
('Parcial 2'),
('Examen Final');

-- Tabla Notas
CREATE TABLE IF NOT EXISTS Notas (
    id_nota INT AUTO_INCREMENT PRIMARY KEY,
    id_estudiante INT NOT NULL,
    id_evaluacion INT NOT NULL,
    nota DECIMAL(4,2) NOT NULL,
    fecha_registro DATE NOT NULL DEFAULT CURRENT_DATE,
    FOREIGN KEY (id_estudiante) REFERENCES Estudiantes(id_estudiante),
    FOREIGN KEY (id_evaluacion) REFERENCES Evaluaciones(id_evaluacion)
);

-- Insertar datos de ejemplo en Notas
INSERT INTO Notas (id_estudiante, id_evaluacion, nota) VALUES
(1, 1, 8.50),
(1, 2, 9.00),
(2, 1, 7.50),
(2, 3, 8.75);
