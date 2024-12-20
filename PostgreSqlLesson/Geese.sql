PGDMP      4            
    |            Geese    17.0    17.0 7    ]           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                           false            ^           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                           false            _           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                           false            `           1262    16744    Geese    DATABASE     {   CREATE DATABASE "Geese" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Russian_Russia.1251';
    DROP DATABASE "Geese";
                     postgres    false            �            1259    16762    eggs    TABLE     �   CREATE TABLE public.eggs (
    egg_id integer NOT NULL,
    goose_id integer,
    egg_weight numeric(5,2),
    egg_color character varying(50),
    laid_date date
);
    DROP TABLE public.eggs;
       public         heap r       postgres    false            �            1259    16761    eggs_egg_id_seq    SEQUENCE     �   CREATE SEQUENCE public.eggs_egg_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 &   DROP SEQUENCE public.eggs_egg_id_seq;
       public               postgres    false    222            a           0    0    eggs_egg_id_seq    SEQUENCE OWNED BY     C   ALTER SEQUENCE public.eggs_egg_id_seq OWNED BY public.eggs.egg_id;
          public               postgres    false    221            �            1259    16774    feed    TABLE     �   CREATE TABLE public.feed (
    feed_id integer NOT NULL,
    feed_name character varying(100),
    feed_type character varying(50)
);
    DROP TABLE public.feed;
       public         heap r       postgres    false            �            1259    16773    feed_feed_id_seq    SEQUENCE     �   CREATE SEQUENCE public.feed_feed_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 '   DROP SEQUENCE public.feed_feed_id_seq;
       public               postgres    false    224            b           0    0    feed_feed_id_seq    SEQUENCE OWNED BY     E   ALTER SEQUENCE public.feed_feed_id_seq OWNED BY public.feed.feed_id;
          public               postgres    false    223            �            1259    16781    feeding_schedule    TABLE     �   CREATE TABLE public.feeding_schedule (
    schedule_id integer NOT NULL,
    goose_id integer,
    feed_id integer,
    feeding_time time without time zone
);
 $   DROP TABLE public.feeding_schedule;
       public         heap r       postgres    false            �            1259    16780     feeding_schedule_schedule_id_seq    SEQUENCE     �   CREATE SEQUENCE public.feeding_schedule_schedule_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 7   DROP SEQUENCE public.feeding_schedule_schedule_id_seq;
       public               postgres    false    226            c           0    0     feeding_schedule_schedule_id_seq    SEQUENCE OWNED BY     e   ALTER SEQUENCE public.feeding_schedule_schedule_id_seq OWNED BY public.feeding_schedule.schedule_id;
          public               postgres    false    225            �            1259    16746    geese    TABLE     �   CREATE TABLE public.geese (
    goose_id integer NOT NULL,
    name character varying(100),
    breed character varying(100),
    age integer,
    weight numeric(5,2),
    date_of_birth date
);
    DROP TABLE public.geese;
       public         heap r       postgres    false            �            1259    16745    geese_goose_id_seq    SEQUENCE     �   CREATE SEQUENCE public.geese_goose_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 )   DROP SEQUENCE public.geese_goose_id_seq;
       public               postgres    false    218            d           0    0    geese_goose_id_seq    SEQUENCE OWNED BY     I   ALTER SEQUENCE public.geese_goose_id_seq OWNED BY public.geese.goose_id;
          public               postgres    false    217            �            1259    16809    goose_owners    TABLE     c   CREATE TABLE public.goose_owners (
    goose_id integer NOT NULL,
    owner_id integer NOT NULL
);
     DROP TABLE public.goose_owners;
       public         heap r       postgres    false            �            1259    16753    owners    TABLE     �   CREATE TABLE public.owners (
    owner_id integer NOT NULL,
    first_name character varying(100),
    last_name character varying(100),
    contact_info text
);
    DROP TABLE public.owners;
       public         heap r       postgres    false            �            1259    16752    owners_owner_id_seq    SEQUENCE     �   CREATE SEQUENCE public.owners_owner_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 *   DROP SEQUENCE public.owners_owner_id_seq;
       public               postgres    false    220            e           0    0    owners_owner_id_seq    SEQUENCE OWNED BY     K   ALTER SEQUENCE public.owners_owner_id_seq OWNED BY public.owners.owner_id;
          public               postgres    false    219            �            1259    16798 
   vet_visits    TABLE     �   CREATE TABLE public.vet_visits (
    visit_id integer NOT NULL,
    goose_id integer,
    visit_date date,
    diagnosis character varying(255)
);
    DROP TABLE public.vet_visits;
       public         heap r       postgres    false            �            1259    16797    vet_visits_visit_id_seq    SEQUENCE     �   CREATE SEQUENCE public.vet_visits_visit_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 .   DROP SEQUENCE public.vet_visits_visit_id_seq;
       public               postgres    false    228            f           0    0    vet_visits_visit_id_seq    SEQUENCE OWNED BY     S   ALTER SEQUENCE public.vet_visits_visit_id_seq OWNED BY public.vet_visits.visit_id;
          public               postgres    false    227            �           2604    16765    eggs egg_id    DEFAULT     j   ALTER TABLE ONLY public.eggs ALTER COLUMN egg_id SET DEFAULT nextval('public.eggs_egg_id_seq'::regclass);
 :   ALTER TABLE public.eggs ALTER COLUMN egg_id DROP DEFAULT;
       public               postgres    false    221    222    222            �           2604    16777    feed feed_id    DEFAULT     l   ALTER TABLE ONLY public.feed ALTER COLUMN feed_id SET DEFAULT nextval('public.feed_feed_id_seq'::regclass);
 ;   ALTER TABLE public.feed ALTER COLUMN feed_id DROP DEFAULT;
       public               postgres    false    224    223    224            �           2604    16784    feeding_schedule schedule_id    DEFAULT     �   ALTER TABLE ONLY public.feeding_schedule ALTER COLUMN schedule_id SET DEFAULT nextval('public.feeding_schedule_schedule_id_seq'::regclass);
 K   ALTER TABLE public.feeding_schedule ALTER COLUMN schedule_id DROP DEFAULT;
       public               postgres    false    226    225    226            �           2604    16749    geese goose_id    DEFAULT     p   ALTER TABLE ONLY public.geese ALTER COLUMN goose_id SET DEFAULT nextval('public.geese_goose_id_seq'::regclass);
 =   ALTER TABLE public.geese ALTER COLUMN goose_id DROP DEFAULT;
       public               postgres    false    217    218    218            �           2604    16756    owners owner_id    DEFAULT     r   ALTER TABLE ONLY public.owners ALTER COLUMN owner_id SET DEFAULT nextval('public.owners_owner_id_seq'::regclass);
 >   ALTER TABLE public.owners ALTER COLUMN owner_id DROP DEFAULT;
       public               postgres    false    219    220    220            �           2604    16801    vet_visits visit_id    DEFAULT     z   ALTER TABLE ONLY public.vet_visits ALTER COLUMN visit_id SET DEFAULT nextval('public.vet_visits_visit_id_seq'::regclass);
 B   ALTER TABLE public.vet_visits ALTER COLUMN visit_id DROP DEFAULT;
       public               postgres    false    227    228    228            S          0    16762    eggs 
   TABLE DATA           R   COPY public.eggs (egg_id, goose_id, egg_weight, egg_color, laid_date) FROM stdin;
    public               postgres    false    222   �?       U          0    16774    feed 
   TABLE DATA           =   COPY public.feed (feed_id, feed_name, feed_type) FROM stdin;
    public               postgres    false    224   a@       W          0    16781    feeding_schedule 
   TABLE DATA           X   COPY public.feeding_schedule (schedule_id, goose_id, feed_id, feeding_time) FROM stdin;
    public               postgres    false    226   �@       O          0    16746    geese 
   TABLE DATA           R   COPY public.geese (goose_id, name, breed, age, weight, date_of_birth) FROM stdin;
    public               postgres    false    218   A       Z          0    16809    goose_owners 
   TABLE DATA           :   COPY public.goose_owners (goose_id, owner_id) FROM stdin;
    public               postgres    false    229   �A       Q          0    16753    owners 
   TABLE DATA           O   COPY public.owners (owner_id, first_name, last_name, contact_info) FROM stdin;
    public               postgres    false    220   �A       Y          0    16798 
   vet_visits 
   TABLE DATA           O   COPY public.vet_visits (visit_id, goose_id, visit_date, diagnosis) FROM stdin;
    public               postgres    false    228   8B       g           0    0    eggs_egg_id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public.eggs_egg_id_seq', 5, true);
          public               postgres    false    221            h           0    0    feed_feed_id_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('public.feed_feed_id_seq', 3, true);
          public               postgres    false    223            i           0    0     feeding_schedule_schedule_id_seq    SEQUENCE SET     N   SELECT pg_catalog.setval('public.feeding_schedule_schedule_id_seq', 5, true);
          public               postgres    false    225            j           0    0    geese_goose_id_seq    SEQUENCE SET     @   SELECT pg_catalog.setval('public.geese_goose_id_seq', 5, true);
          public               postgres    false    217            k           0    0    owners_owner_id_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('public.owners_owner_id_seq', 3, true);
          public               postgres    false    219            l           0    0    vet_visits_visit_id_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('public.vet_visits_visit_id_seq', 5, true);
          public               postgres    false    227            �           2606    16767    eggs eggs_pkey 
   CONSTRAINT     P   ALTER TABLE ONLY public.eggs
    ADD CONSTRAINT eggs_pkey PRIMARY KEY (egg_id);
 8   ALTER TABLE ONLY public.eggs DROP CONSTRAINT eggs_pkey;
       public                 postgres    false    222            �           2606    16779    feed feed_pkey 
   CONSTRAINT     Q   ALTER TABLE ONLY public.feed
    ADD CONSTRAINT feed_pkey PRIMARY KEY (feed_id);
 8   ALTER TABLE ONLY public.feed DROP CONSTRAINT feed_pkey;
       public                 postgres    false    224            �           2606    16786 &   feeding_schedule feeding_schedule_pkey 
   CONSTRAINT     m   ALTER TABLE ONLY public.feeding_schedule
    ADD CONSTRAINT feeding_schedule_pkey PRIMARY KEY (schedule_id);
 P   ALTER TABLE ONLY public.feeding_schedule DROP CONSTRAINT feeding_schedule_pkey;
       public                 postgres    false    226            �           2606    16751    geese geese_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public.geese
    ADD CONSTRAINT geese_pkey PRIMARY KEY (goose_id);
 :   ALTER TABLE ONLY public.geese DROP CONSTRAINT geese_pkey;
       public                 postgres    false    218            �           2606    16813    goose_owners goose_owners_pkey 
   CONSTRAINT     l   ALTER TABLE ONLY public.goose_owners
    ADD CONSTRAINT goose_owners_pkey PRIMARY KEY (goose_id, owner_id);
 H   ALTER TABLE ONLY public.goose_owners DROP CONSTRAINT goose_owners_pkey;
       public                 postgres    false    229    229            �           2606    16760    owners owners_pkey 
   CONSTRAINT     V   ALTER TABLE ONLY public.owners
    ADD CONSTRAINT owners_pkey PRIMARY KEY (owner_id);
 <   ALTER TABLE ONLY public.owners DROP CONSTRAINT owners_pkey;
       public                 postgres    false    220            �           2606    16803    vet_visits vet_visits_pkey 
   CONSTRAINT     ^   ALTER TABLE ONLY public.vet_visits
    ADD CONSTRAINT vet_visits_pkey PRIMARY KEY (visit_id);
 D   ALTER TABLE ONLY public.vet_visits DROP CONSTRAINT vet_visits_pkey;
       public                 postgres    false    228            �           2606    16768    eggs eggs_goose_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.eggs
    ADD CONSTRAINT eggs_goose_id_fkey FOREIGN KEY (goose_id) REFERENCES public.geese(goose_id) ON DELETE CASCADE;
 A   ALTER TABLE ONLY public.eggs DROP CONSTRAINT eggs_goose_id_fkey;
       public               postgres    false    222    218    4778            �           2606    16792 .   feeding_schedule feeding_schedule_feed_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.feeding_schedule
    ADD CONSTRAINT feeding_schedule_feed_id_fkey FOREIGN KEY (feed_id) REFERENCES public.feed(feed_id);
 X   ALTER TABLE ONLY public.feeding_schedule DROP CONSTRAINT feeding_schedule_feed_id_fkey;
       public               postgres    false    4784    226    224            �           2606    16787 /   feeding_schedule feeding_schedule_goose_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.feeding_schedule
    ADD CONSTRAINT feeding_schedule_goose_id_fkey FOREIGN KEY (goose_id) REFERENCES public.geese(goose_id) ON DELETE CASCADE;
 Y   ALTER TABLE ONLY public.feeding_schedule DROP CONSTRAINT feeding_schedule_goose_id_fkey;
       public               postgres    false    218    4778    226            �           2606    16814 '   goose_owners goose_owners_goose_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.goose_owners
    ADD CONSTRAINT goose_owners_goose_id_fkey FOREIGN KEY (goose_id) REFERENCES public.geese(goose_id) ON DELETE CASCADE;
 Q   ALTER TABLE ONLY public.goose_owners DROP CONSTRAINT goose_owners_goose_id_fkey;
       public               postgres    false    4778    218    229            �           2606    16819 '   goose_owners goose_owners_owner_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.goose_owners
    ADD CONSTRAINT goose_owners_owner_id_fkey FOREIGN KEY (owner_id) REFERENCES public.owners(owner_id) ON DELETE CASCADE;
 Q   ALTER TABLE ONLY public.goose_owners DROP CONSTRAINT goose_owners_owner_id_fkey;
       public               postgres    false    4780    220    229            �           2606    16804 #   vet_visits vet_visits_goose_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.vet_visits
    ADD CONSTRAINT vet_visits_goose_id_fkey FOREIGN KEY (goose_id) REFERENCES public.geese(goose_id) ON DELETE CASCADE;
 M   ALTER TABLE ONLY public.vet_visits DROP CONSTRAINT vet_visits_goose_id_fkey;
       public               postgres    false    218    228    4778            S   _   x�m��� ��l.P�j0c
��9p�Ø�P������[W�Y`j�����}<�r���X��g�����{O���m�^����2{y�8      U   H   x�3�0�¾��(r^Xx��b�}vr!ā�Iv_�paۅ���r�9 s���v_������� 8�/�      W   8   x�3�4B+ �2�AK(ט̭��\N�bה����8F��� �&j      O   �   x�U̽1@�ڞ�l�'�.7��TLpB��l�]�@��OO!���N��S�[.�n�|�C�	���RCr�g.혟nT�n���}X����4� ,C��k��}�z �Hc�5��R�����T2Ù��}U$      Z      x�3�4�2�4�2�4�2�M��=... '�       Q   b   x�3�0�¦.�3.컰�3�,1/��!�"1� 'U/9?�ˈ���[/6]l�3�JRK�Дs^XT�pa�v"s�5���������� _H	      Y   ^   x�U��	�0���d�J��N�0n�Z,bg87��T�v�q����'ѩ�(����F�[�͓�lt��
�g�ڊ�ʉ�T���#�VP�����M@�     