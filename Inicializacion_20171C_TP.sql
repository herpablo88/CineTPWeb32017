USE [20171C_TP]
GO

---Necesario antes de correr la app por primera vez---

INSERT into dbo.TiposDocumentos VALUES
('DNI'), ('CARNET EXT.'), 
('PASAPORTE'), ('RUC')
GO

INSERT into dbo.Usuarios VALUES
('Admin',123)
GO

INSERT into dbo.Calificaciones VALUES
('ATP'),
('PM13'), ('PM13R'),
('PM16'), ('PM16R'),
('PM18')
GO

INSERT into dbo.Generos VALUES
('Acción'), ('Animación'), ('Aventuras'), 
('Ciencia ficción'), ('Comedia'), ('Comedia romantica'),
('Drama'), ('Infantil'), ('Opera'), ('Romance'),  
('Suspenso'), ('Terror'), ('Thriller')
GO

INSERT into dbo.Versiones VALUES
('Castellano'), ('Subtitulada')
GO

---Registros de ejemplo pero pueden cargarse desde la app---

INSERT into dbo.Sedes VALUES
('San Justo','Arieta 2900',125),
('Morón','25 de Mayo 200',130),
('Casanova', 'Necochea 100',135)
GO

DECLARE @ruta nvarchar(250)
SET @ruta='/Imagenes/'
INSERT into dbo.Peliculas VALUES
('BAYWATCH Guardianes de la bahía','Sigue al devoto salvavidas Mitch Buchannon (Johnson) mientras se enfrenta con un nuevo recluta bastante atolondrado (Efron). Juntos, descubren un plan criminal que pone en peligro el futuro de la bahía.',
@ruta+'baywatch.jpg', 4, 5, 116, GETDATE()),
('El Bar','La barra de un bar un día cualquiera a media mañana. Clientes de toda la vida y desconocidos compartiendo churros, porras y mixtos bajo la dirección implacable de Amparo, la dueña del bar. Mientras tanto Satur, el camarero que lleva trabajando allí más tiempo que la máquina del café, se alegra la vista con la llegada de Elena, una joven que acude a una cita y ha tenido que hacer escala en el bar para recargar su teléfono.',
@ruta+'el_bar.jpg', 4, 11, 102, GETDATE()),
('Aplicación Siniestra', 'Un grupo de amigos descargan una aplicación para el móvil similar a Siri. Pero lo que parece un inofensivo sistema para obtener direcciones y recomendaciones de restaurantes esconde una siniestra naturaleza. La aplicación no solo es capaz de conocer los miedos más secretos y ocultos de una persona, sino que además es capaz de manifestarlos en el mundo real hasta lograr matar de miedo a los niños.',
@ruta+'aplicacion_siniestra.jpg', 3, 12, 91, GETDATE()),
('Todo Todo', 'Cuenta la improbable historia de amor de Maddy, una chica de 18 años de edad, inteligente, curiosa y creativa que, a causa de una enfermedad, no puede abandonar el ambiente protegido herméticamente de su casa; y de Olly, el nuevo vecino de a lado y que no permitirá que eso los detenga. Maddy está desesperada por conocer y experimentar el mundo exterior mucho más emocionante que el suyo- y vivir la promesa de su primer amor. Gracias a la comunicación que mantienen vía mensajes de texto y al intercambio de miradas por la ventana, Olly y Maddy forman un fuerte vínculo que los lleva a arriesgar todo para estar juntos... incluso si eso significa perderlo todo.',
@ruta+'todo_todo.jpg', 2, 10, 96, GETDATE()),
('El Mago de Oz', 'La película está basada en la novela infantil de L. Frank Baum El maravilloso mago de Oz,4 en la cual una joven estadounidense es arrastrada por un tornado en el estado de Kansas y dejada en una fantástica tierra donde habitan brujas buenas y malas, un espantapájaros que habla, un león cobarde, un hombre de hojalata y otros seres extraordinarios.',
@ruta+'el_mago_de_oz.jpg', 1, 3, 102, GETDATE()),
('Una cigüeña en apuros', 'Aunque todo el mundo sabe que es un gorrión, Richard está convencido de que es una cigüeña y su mayor deseo es viajar a África antes de que llegue el invierno, junto a su familia adoptiva y las demás cigüeñas. ¿Conseguirá este pequeño superar los peligros y alcanzar su sueño?',
@ruta+'una_ciguena_en_apuros.jpg', 1, 8, 85, GETDATE()),
('Koe no katachi Una voz silenciosa', '¿Te has arrepentido de algo? Shoya era un niño que molestó a Shoko la nueva niña del salón por ser sorda. Las burlas de este continuaron hasta que Shoko se cambió de escuela. Varios años después un atormentado Shoya busca reencontrarse con su ex-compañera y redimirse ¿Podrá ella perdonarlo o será demasiado tarde?',
@ruta+'koe_no_katachi.jpg', 4, 10, 129, GETDATE()),
('Dulces sueños', 'Turín, 1969. La idílica infancia de Massimo se ve truncada a los nueve años por la inexplicable muerte de su madre. 30 años después, tras pasar por la guerra de Sarajevo como periodista, empezará a sufrir ataques de pánico. Mientras se prepara para vender el departamento familiar, Elisa intentará ayudarlo a enfrentarse a las heridas de su pasado.',
@ruta+'dulces_suenos.jpg', 3, 7, 134, GETDATE())
GO 

INSERT into dbo.Carteleras VALUES
(1, 1, 11, GETDATE()-1, GETDATE()+10, 1, 1, 1, 1, 1, 1, 1, 1, 1, GETDATE()-2),  
(1, 1, 12, GETDATE()-1, GETDATE()+10, 2, 2, 0, 0, 0, 1, 1, 1, 1, GETDATE()-2),  
(2, 1, 10, GETDATE()-1, GETDATE()+10, 1, 1, 0, 1, 1, 1, 1, 1, 1, GETDATE()-2),  
(2, 1, 18, GETDATE()-1, GETDATE()+10, 2, 2, 0, 0, 0, 1, 1, 1, 1, GETDATE()-2),
(3, 1, 10, GETDATE()-1, GETDATE()+10, 1, 1, 1, 1, 1, 1, 1, 1, 1, GETDATE()-2),  
(3, 1, 15, GETDATE()-1, GETDATE()+10, 2, 2, 1, 1, 1, 1, 1, 1, 1, GETDATE()-2), 
(1, 2, 15, GETDATE()-1, GETDATE()+10, 3, 1, 0, 0, 0, 1, 1, 1, 1, GETDATE()-2),
(1, 2, 15, GETDATE()-1, GETDATE()+10, 4, 2, 0, 0, 0, 1, 1, 1, 1, GETDATE()-2), 
(2, 2, 16, GETDATE()-1, GETDATE()+10, 3, 1, 0, 0, 0, 1, 1, 1, 1, GETDATE()-2),
(1, 3, 15, GETDATE()-1, GETDATE()+10, 5, 1, 0, 0, 1, 1, 1, 1, 1, GETDATE()-2),
(1, 3, 15, GETDATE()-1, GETDATE()+10, 6, 2, 0, 0, 0, 0, 1, 1, 1, GETDATE()-2),
(3, 3, 16, GETDATE()-1, GETDATE()+10, 3, 1, 1, 1, 1, 1, 1, 1, 1, GETDATE()-2),
(3, 3, 16, GETDATE()-1, GETDATE()+10, 4, 2, 0, 0, 0, 1, 1, 1, 1, GETDATE()-2),
(3, 4, 15, GETDATE()-1, GETDATE()+10, 5, 1, 1, 1, 1, 1, 1, 1, 1, GETDATE()-2),
(3, 4, 15, GETDATE()-1, GETDATE()+10, 6, 2, 1, 0, 0, 1, 1, 1, 1, GETDATE()-2),
(1, 5, 16, GETDATE()-1, GETDATE()+10, 7, 1, 1, 1, 1, 1, 1, 1, 1, GETDATE()-2),
(1, 5, 16, GETDATE()-1, GETDATE()+10, 8, 2, 0, 0, 0, 1, 1, 1, 1, GETDATE()-2),
(2, 5, 16, GETDATE()-1, GETDATE()+10, 4, 1, 1, 1, 1, 1, 1, 1, 1, GETDATE()-2),
(2, 5, 16, GETDATE()-1, GETDATE()+10, 5, 2, 1, 1, 1, 1, 1, 1, 1, GETDATE()-2),
(1, 6, 15, GETDATE()-1, GETDATE()+10, 9, 1, 1, 1, 1, 1, 1, 1, 1, GETDATE()-2),
(2, 6, 15, GETDATE()-1, GETDATE()+10, 6, 1, 1, 1, 1, 1, 1, 1, 1, GETDATE()-2),
(3, 6, 15, GETDATE()-1, GETDATE()+10, 7, 1, 1, 1, 1, 1, 1, 1, 1, GETDATE()-2),
(2, 7, 15, GETDATE()-1, GETDATE()+10, 7, 1, 1, 1, 1, 1, 1, 1, 1, GETDATE()-2),
(2, 7, 15, GETDATE()-1, GETDATE()+10, 8, 2, 1, 1, 1, 1, 1, 0, 0, GETDATE()-2),
(3, 7, 16, GETDATE()-1, GETDATE()+10, 8, 1, 1, 1, 1, 1, 1, 1, 1, GETDATE()-2),
(3, 7, 16, GETDATE()-1, GETDATE()+10, 9, 2, 0, 0, 0, 1, 1, 1, 1, GETDATE()-2),
(3, 8, 16, GETDATE()-1, GETDATE()+10, 10, 1, 1, 1, 1, 1, 1, 1, 1, GETDATE()-2),
(3, 8, 16, GETDATE()-1, GETDATE()+10, 11, 2, 1, 1, 1, 1, 1, 1, 1, GETDATE()-2)
GO


DECLARE @email1 nvarchar(250), @email2 nvarchar(250)
SET @email1 = 'persona1@gmail.com' 
SET @email2 = 'persona2@gmail.com' 
INSERT into dbo.Reservas VALUES
(1, 1, 1, GETDATE()+5, @email1, 1, '11111111', 2, GETDATE()),
(3, 2, 1, GETDATE()+3, @email2, 1, '22222222', 5, GETDATE())
GO

