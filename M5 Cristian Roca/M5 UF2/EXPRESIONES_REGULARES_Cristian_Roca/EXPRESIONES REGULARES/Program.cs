#include <stdio.h>
#include <string.h>
#include <regex.h>

// 1. Buscar palabras con la letra 'e'
void buscar_palabras_con_e(const char *texto) {
    regex_t regex;
    if (regcomp(&regex, "\\b\\w*e\\w*\\b", REG_EXTENDED) != 0) {
        printf("Error al compilar la expresión regular.\n");
        return;
    }
    regmatch_t match[1];

    const char *p = texto;
    printf("1. Palabras con 'e':\n");
    while (regexec(&regex, p, 1, match, 0) == 0) {
        printf("%.*s\n", (int)(match[0].rm_eo - match[0].rm_so), p + match[0].rm_so);
        p += match[0].rm_eo;
    }
    regfree(&regex);
}

// 2. Buscar palabras que terminan en 'dad'
void buscar_palabras_final_dad(const char *texto) {
    regex_t regex;
    if (regcomp(&regex, "\\b\\w*d[aá]d\\b", REG_EXTENDED) != 0) {
        printf("Error al compilar la expresión regular.\n");
        return;
    }
    regmatch_t match[1];

    const char *p = texto;
    printf("\n2. Palabras que terminan en 'dad':\n");
    while (regexec(&regex, p, 1, match, 0) == 0) {
        printf("%.*s\n", (int)(match[0].rm_eo - match[0].rm_so), p + match[0].rm_so);
        p += match[0].rm_eo;
    }
    regfree(&regex);
}

// 3. Buscar la palabra 'lenguajes'
void buscar_palabra_lenguajes(const char *texto) {
    regex_t regex;
    if (regcomp(&regex, "\\blenguajes\\b", REG_EXTENDED) != 0) {
        printf("Error al compilar la expresión regular.\n");
        return;
    }
    regmatch_t match[1];

    const char *p = texto;
    printf("\n3. Palabra 'lenguajes':\n");
    while (regexec(&regex, p, 1, match, 0) == 0) {
        printf("%.*s\n", (int)(match[0].rm_eo - match[0].rm_so), p + match[0].rm_so);
        p += match[0].rm_eo;
    }
    regfree(&regex);
}

// 4. Buscar palabras que inicien con 's' y terminen con 'n'
void buscar_palabras_s_n(const char *texto) {
    regex_t regex;
    if (regcomp(&regex, "\\bs\\w*n\\b", REG_EXTENDED) != 0) {
        printf("Error al compilar la expresión regular.\n");
        return;
    }
    regmatch_t match[1];

    const char *p = texto;
    printf("\n4. Palabras que inician con 's' y terminan con 'n':\n");
    while (regexec(&regex, p, 1, match, 0) == 0) {
        printf("%.*s\n", (int)(match[0].rm_eo - match[0].rm_so), p + match[0].rm_so);
        p += match[0].rm_eo;
    }
    regfree(&regex);
}

// 5. Buscar número de teléfono '9876543210'
void buscar_numeros_telefono(const char *texto) {
    regex_t regex;
    if (regcomp(&regex, "\\b9876543210\\b", REG_EXTENDED) != 0) {
        printf("Error al compilar la expresión regular.\n");
        return;
    }
    regmatch_t match[1];

    const char *p = texto;
    printf("\n5. Números de teléfono:\n");
    while (regexec(&regex, p, 1, match, 0) == 0) {
        printf("%.*s\n", (int)(match[0].rm_eo - match[0].rm_so), p + match[0].rm_so);
        p += match[0].rm_eo;
    }
    regfree(&regex);
}

// 6. Buscar correos que terminan en '.es'
void buscar_correos_es(const char *texto) {
    regex_t regex;
    if (regcomp(&regex, "\\b[a-zA-Z0-9._%+-]+@[\\w.-]+\\.es\\b", REG_EXTENDED) != 0) {
        printf("Error al compilar la expresión regular.\n");
        return;
    }
    regmatch_t match[1];

    const char *p = texto;
    printf("\n6. Correos que terminan con '.es':\n");
    while (regexec(&regex, p, 1, match, 0) == 0) {
        printf("%.*s\n", (int)(match[0].rm_eo - match[0].rm_so), p + match[0].rm_so);
        p += match[0].rm_eo;
    }
    regfree(&regex);
}

// 7. Buscar palabras que inicien con 'a' y tengan al menos 5 caracteres
void buscar_palabras_a_largas(const char *texto) {
    regex_t regex;
    if (regcomp(&regex, "\\ba\\w{4,}\\b", REG_EXTENDED) != 0) {
        printf("Error al compilar la expresión regular.\n");
        return;
    }
    regmatch_t match[1];

    const char *p = texto;
    printf("\n7. Palabras con 'a' y mín. 5 caracteres:\n");
    while (regexec(&regex, p, 1, match, 0) == 0) {
        printf("%.*s\n", (int)(match[0].rm_eo - match[0].rm_so), p + match[0].rm_so);
        p += match[0].rm_eo;
    }
    regfree(&regex);
}

// 8. Buscar palabras solo en minúsculas
void buscar_palabras_minusculas(const char *texto) {
    regex_t regex;
    if (regcomp(&regex, "\\b[a-z]+\\b", REG_EXTENDED) != 0) {
        printf("Error al compilar la expresión regular.\n");
        return;
    }
    regmatch_t match[1];

    const char *p = texto;
    printf("\n8. Palabras solo minúsculas:\n");
    while (regexec(&regex, p, 1, match, 0) == 0) {
        printf("%.*s\n", (int)(match[0].rm_eo - match[0].rm_so), p + match[0].rm_so);
        p += match[0].rm_eo;
    }
    regfree(&regex);
}

int main() {
    const char *texto = 
    "Los correos electrónicos son una forma común de comunicación en la era digital. Un correo electrónico consta de varias partes, "
    "como el remitente, el destinatario, el asunto y el cuerpo del mensaje. Algunos ejemplos de direcciones de correo electrónico son: "
    "usuario@gmail.com, contacto@empresa.es y teléfono 987654321 o 9876543210. En el ámbito de la programación, las expresiones regulares "
    "son útiles para validar y buscar patrones en direcciones de correo electrónico. Las expresiones regulares se pueden utilizar en muchos "
    "lenguajes de programación, incluyendo Python, JavaScript y Java.";

    buscar_palabras_con_e(texto);
    buscar_palabras_final_dad(texto);
    buscar_palabra_lenguajes(texto);
    buscar_palabras_s_n(texto);
    buscar_numeros_telefono(texto);  
    buscar_correos_es(texto);
    buscar_palabras_a_largas(texto);
    buscar_palabras_minusculas(texto);

    return 0;
}












